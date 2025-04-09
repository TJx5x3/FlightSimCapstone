// === Analog Inputs ===
const byte analogPins[] = { A0, A1, A2, A3, A4, A5, A6, A7, A8, A9 };
const byte NUM_ANALOG = sizeof(analogPins) / sizeof(analogPins[0]);
int analogValues[NUM_ANALOG];

// === Flap LEDs ===
// 0° → Pin 5, 10° → Pin 4, 20° → Pin 7, 30° → Pin 6
const byte flapLEDs[] = {5, 4, 7, 6};
const byte NUM_FLAP_LEDS = sizeof(flapLEDs) / sizeof(flapLEDs[0]);

void setup() {
  Serial.begin(9600);

  // Initialize flap LED pins
  for (byte i = 0; i < NUM_FLAP_LEDS; i++) {
    pinMode(flapLEDs[i], OUTPUT);
    digitalWrite(flapLEDs[i], LOW);
  }
}

void loop() {
  static unsigned long timer = 0;
  const unsigned long interval = 500;

  if (millis() - timer >= interval) {
    timer = millis();

    // === Read A0–A8 (raw values)
    for (byte i = 0; i < NUM_ANALOG - 1; i++) {
      analogValues[i] = analogRead(analogPins[i]);
      Serial.print(analogValues[i]);
      Serial.print(", ");
    }

    // === Read A9 and convert to flap angle
    int flapRaw = analogRead(A9);
    byte flapAngle = getFlapAngle(flapRaw);
    analogValues[9] = flapAngle;

    Serial.println(flapAngle); // Last value in line, no comma
    updateFlapLEDs(flapAngle);
  }
}

// === Convert analog value to flap angle
byte getFlapAngle(int value) {
  if (value >= 350 && value <= 450) return 30;
  else if (value > 450 && value <= 520) return 20;
  else if (value > 520 && value <= 620) return 10;
  else return 0;
}

// === Update flap LEDs
void updateFlapLEDs(byte angle) {
  for (byte i = 0; i < NUM_FLAP_LEDS; i++) {
    digitalWrite(flapLEDs[i], LOW);
  }

  byte index = angle / 10;
  if (index < NUM_FLAP_LEDS) {
    digitalWrite(flapLEDs[index], HIGH);
  }
}
