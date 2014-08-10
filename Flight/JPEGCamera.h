
/* Arduino JPeg Camera Library
 * Copyright 2010 SparkFun Electronics
 * Written by Ryan Owens
 * Modified by Emmanuel ALLAUD, 2013
 * Changes:
 *   - updated to work with arduino-1.0 and up
 *   - Use a serial class for communication to 
 *     be able to use either a hardware or software serial
*/

#ifndef JPEGCamera_h
#define JPEGCamera_h

#include <avr/pgmspace.h>
#include "Arduino.h"

// Max size to be read in one chunk

#define JPEGCAM_READ_SIZE 32

class JPEGCamera
{
 public:
  // Param must derive from Stream, as the serial classes, and must have begun at 38400 bds
  JPEGCamera(Stream& comm);
  void setPort(Stream& comm) { cameraPort = comm; }
  void reset();
  unsigned int getSize();
  void takePicture();
  void stopPictures();
  void powerSaving(bool); // true -> power saving , false = exit power saving
  int getData(Stream& output);
  void chPictureSize(byte p_size); // 0 -> 160x120 / 1 -> 320x240 / 2-> 640x480
  void chBaudRate(byte rate); // 0 -> 9600 / 1 -> 19200 / 2 ->  38400 / 3 -> 57600 / 4 -> 115200
  
 private:
  int sendCommand(const char * command, char * response, int length);
  Stream& cameraPort;
};

#endif
