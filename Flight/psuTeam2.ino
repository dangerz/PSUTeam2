// Tx-Brown, Rx-Red, Gnd-Purple, Vcc-Grey

#include <Adafruit_GPS.h>
#include <SoftwareSerial.h>
#include <JPEGCamera.h>

Adafruit_GPS GPS( &Serial2 );

#define GPSECHO  false

// this keeps track of whether we're using the interrupt
// off by default!
boolean usingInterrupt = false;
void useInterrupt(boolean); // Func prototype keeps Arduino 0023 happy

JPEGCamera cam( Serial1 );

char resp[10];
const int led = 13;
const int SLEEP_TIME = 25; // how long should we sleep before taking another picture?
const int MAX_INPUT_STRING_LENGTH = 100;

const String THIS_ID = "pl1";
const String PICTURE_TAKE_COMMAND = "pct";
const String PICTURE_SEND_COMMAND = "pcr";
const String GPS_SEND_COMMAND = "gps";
const String BUFFER_CLEAR_COMMAND = "bfc";
const String COMMAND_ENDER = ",~!";

const int ID_LENGTH = 3; // how long is our id?
const int CMD_LENGTH = 3; // how long is each command?
const int WAIT_TIME_BEFORE_SENDING_PICTURE = 7000; // how many milliseconds should we wait before sending the picture?  this is to give the ground station enough time to buffer the current commands
const int WAIT_TIME_AFTER_SENDING_PICTURE = 20000; // how many milliseconds should we wait for the ground station to receive the picture?

void setup()
{
  Serial.begin( 38400 ); // open the xbee port

  pinMode( led, OUTPUT );

  // Wait for the serial port to be opened
  while (!Serial) delay( 25 );

  // 9600 NMEA is the default baud rate for MTK - some use 4800
  GPS.begin(9600);
  
  GPS.sendCommand(PMTK_SET_NMEA_OUTPUT_RMCGGA);
  GPS.sendCommand(PMTK_SET_NMEA_UPDATE_1HZ);
  GPS.sendCommand(PGCMD_ANTENNA);

  useInterrupt( true );

  delay ( 500 );
  
  Serial1.begin( 38400 ); // open the camera port

  digitalWrite( led, HIGH );   // turn the LED on (HIGH is the voltage level)
  delay( 100 );               // wait for a second

  cam.reset(); // initialize

  delay( 500 );

  digitalWrite( led, LOW );    // turn the LED off by making the voltage LOW
}

uint32_t timer = millis();
void loop()
{
  processInput();
  // if a sentence is received, we can check the checksum, parse it...
  if (GPS.newNMEAreceived()) {
    if (!GPS.parse(GPS.lastNMEA()))   // this also sets the newNMEAreceived() flag to false
      return;  // we can fail to parse a sentence in which case we should just wait for another
  }

  if (timer > millis()) 
    timer = millis();

  if (millis() - timer > 1000)
  {
    timer = millis(); // reset the timer
    if ( GPS.fix )
    {
      Serial.print( THIS_ID + GPS_SEND_COMMAND + GPS.lastNMEA() + COMMAND_ENDER );
    } else {
      Serial.print( THIS_ID + GPS_SEND_COMMAND + "NoFix" + COMMAND_ENDER );
    }
  }
}

void processInput()
{  
  if ( Serial.available() )
  {
    boolean keepReading = true;
    String totalInputString = Serial.readString();

    if ( totalInputString.length() > ID_LENGTH + CMD_LENGTH ) // only process if the command has enough data
    {
      digitalWrite( led, HIGH );   // turn the LED on (HIGH is the voltage level)
      if ( totalInputString.substring ( ID_LENGTH, ID_LENGTH + CMD_LENGTH ) == PICTURE_TAKE_COMMAND ) // is it a picture command?
      {
        if ( totalInputString.substring ( ID_LENGTH + CMD_LENGTH, ID_LENGTH + CMD_LENGTH + ID_LENGTH ) == THIS_ID ) // if it is, is the command for us?
        {
          digitalWrite( led, LOW );   // turn the LED off
          takePicture();
          Serial.print( THIS_ID + BUFFER_CLEAR_COMMAND + COMMAND_ENDER );
          delay( WAIT_TIME_BEFORE_SENDING_PICTURE ); // let the ground station clear it's buffer before sending
          sendPicture();
          resetCamera();
          delay( WAIT_TIME_AFTER_SENDING_PICTURE ); // let the ground station receive all the data before sending more
        }
      }
    }
  }
}
// Start Camera Methods
void takePicture()
{
  digitalWrite( led, HIGH );   // turn the LED on (HIGH is the voltage level)
  delay( 100 );               // wait for a second

  cam.takePicture(); // take the picture

  digitalWrite( led, LOW );    // turn the LED off by making the voltage LOW
  delay( 100 );               // wait for a second 
}
void sendPicture()
{
  Serial.print( THIS_ID + PICTURE_SEND_COMMAND );
  delay ( 4000 );
  cam.getData( Serial ); // print the data
  delay ( 4000 );
  Serial.print( COMMAND_ENDER );
}
void resetCamera()
{
  cam.stopPictures(); // stop taking pictures 

  int i = 0; // cool down
  while ( i < SLEEP_TIME ) 
  {
    digitalWrite( led, HIGH );
    delay( 100 );
    digitalWrite( led, LOW );
    delay( 100 );
    i++;
  }
}
// End Camera Methods
// Start GPS Methods
// Interrupt is called once a millisecond, looks for any new GPS data, and stores it
SIGNAL(TIMER0_COMPA_vect) {
  char c = GPS.read();
  // if you want to debug, this is a good time to do it!
#ifdef UDR0
  if (GPSECHO)
    if (c) UDR0 = c;  
    // writing direct to UDR0 is much much faster than Serial.print 
    // but only one character can be written at a time. 
#endif
}

void useInterrupt(boolean v) {
  if (v) {
    // Timer0 is already used for millis() - we'll just interrupt somewhere
    // in the middle and call the "Compare A" function above
    OCR0A = 0xAF;
    TIMSK0 |= _BV(OCIE0A);
    usingInterrupt = true;
  } else {
    // do not call the interrupt function COMPA anymore
    TIMSK0 &= ~_BV(OCIE0A);
    usingInterrupt = false;
  }
}
// End GPS Methods
