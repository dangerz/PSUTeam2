#include <XBee.h>

XBee xbee = XBee();
uint8_t payload[] = { 'H', 'i' };

// SH + SL Address of receiving XBee
XBeeAddress64 addr64 = XBeeAddress64(0x0013a200, 40AD614A);
ZBTxRequest zbTx = ZBTxRequest(addr64, payload, sizeof(payload));

ZBTxStatusResponse txStatus = ZBTxStatusResponse();


void setup() {
    pinMode(13, OUTPUT);

    Serial.begin(9600);
    xbee.setSerial(Serial);
    Serial.println("Ready for action");
}



void loop() 
{
    xbee.send(zbTx);
    delay(1000);

    xbee.readPacket();
    if (xbee.getResponse().isAvailable()) {

        // Response received, blink LED once
        Serial.println('Response!');
        digitalWrite(13, HIGH);
        delay(1000);
        digitalWrite(13, LOW);
        delay(1000);
    }

}
