/**********************************************************************************
 *  Author          :   Jason Broom
 *  Course Number   :   STG-452
 *  Last Revision   :   2/23/25
 *  Class           :   SimConnectUtility.cs
 *  Description     :   This module defines the Developer Form. This is a secret
 *                      form that can be launched by pressing F6 from the Utility
 *                      Form.
 *                      
 *                      This form is to display Diagnostics and/or test features
 *                      before they are integrated into the application visible
 *                      to the end user.
 **********************************************************************************
 *  I used source code from the following websites to complete
 *  this assignment:
 *  
 *  Proper attribute initialization in C#
 *  https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions
 *
 *  Attribute Properties syntax:
 *  https://www.w3schools.com/cs/cs_properties.php
 *  
 *  Establishing and terminating connection to SimConnect Client
 *  https://docs.flightsimulator.com/html/Programming_Tools/SimConnect/Programming_SimConnect_Clients_using_Managed_Code.htm
 *  
 *  Troubleshooting missing DLL Dependencies
 *  https://forums.flightsimulator.com/t/c-simconnect-error/324090
 *  
 *  Requesting data from SimConnect API
 *  https://docs.flightsimulator.com/html/Programming_Tools/SimConnect/API_Reference/Events_And_Data/SimConnect_RequestDataOnSimObject.htm
 *  
 *  Handling SimConnect data transmission upon successful SimConnect Connection:
 *  https://docs.flightsimulator.com/html/Programming_Tools/SimConnect/API_Reference/Structures_And_Enumerations/SIMCONNECT_RECV_SIMOBJECT_DATA.htm
 *  
 *  Aircraft Fuel Variables:
 *  https://docs.flightsimulator.com/html/Programming_Tools/SimVars/Aircraft_SimVars/Aircraft_Fuel_Variables.htm
 *  
 *  Aircraft Electrical Variables:
 *  https://docs.flightsimulator.com/html/Programming_Tools/SimVars/Aircraft_SimVars/Aircraft_Electrics_Variables.htm
 *  
 *  MSFS Input Mapping
 *  https://docs.flightsimulator.com/html/Programming_Tools/SimConnect/API_Reference/Events_And_Data/SimConnect_MapClientEventToSimEvent.htm
 *  
 *  Date & Time Simulation variables
 *  https://docs.flightsimulator.com/html/Programming_Tools/WASM/Gauge_API/Token_Vars/General_Simulation.htm?rhhlterm=clock_hour&rhsearch=CLOCK_hour
 **********************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using Microsoft.FlightSimulator.SimConnect;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Runtime.CompilerServices;


namespace FlightSimCapstone
{
    /// <summary>
    /// This class provides various methods to handle the creation, termination, and data handling
    /// of the SimConnect client.
    /// </summary>
    /// <remarks>
    /// This class declares the datatypes of all values retrieved from SimConnect,
    /// and maps 
    /// </remarks>
    public static class SimConnectUtility
    {
        // Initialize SimConnect
        static SimConnect simconnect = null;
        const int WM_USER_SIMCONNECT = 0x0402;

        // Simconnect Window Handler (Necessary for establishing SimConnect Connection)
        static IntPtr windowHandle;

        // Status info
        private static bool connectionStatus = false; // Simconnect Client established
        private static bool readingsInitialized = false; // Simconnect values initialized

        private static bool brakeEnable = false;

        // TODO: Tweak this, get proper get/set logic
        // Getter/setter
        public static bool ConnectionStatus
        {
            get { return (simconnect != null); }
            set { connectionStatus = false; }
        }

        // Retrieved simconnect data attributes
        private static double altimeterValue = 0.0;
        private static double headingIndicatorValue = 0.0f;
        private static double turnCoordinatorValue = 0.0f;
        private static double turnIndicatorValue = 0.0f;
        private static double airspeedIndicatorValue = 0.0f;
        private static double verticalAirspeedIndicatorValue = 0.0f;
        private static double suctionGaugeValue = 0.0f;
        private static double totalFuelValue = 0.0f;
        private static double currentFuelValue = 0.0f;
        private static double ammeterValue = 0.0f;
        private static double pitchValue = 0.0f;
        private static double rollValue = 0.0f;

        private static double hourValue = 0.0f;
        private static double minuteValue = 0.0f;
        private static double secondValue = 0.0f;



        private static double throttleValue = 0.0f;
        private static double mixtureValue = 0.0f;
        private static double trimWheellValue = 0.0f;
        private static int flapSwitchValue = 0;


        // getter/setter properties for simconnect attributes
        public static double AltimeterValue
        {
            get { return altimeterValue; }
            private set { altimeterValue = value; }
        }

        public static double HeadingIndicatorValue
        {
            get { return headingIndicatorValue; }
            private set { headingIndicatorValue = value; }
        }

        public static double TurnCoordinatorValue
        {
            get { return turnCoordinatorValue; }
            private set { turnCoordinatorValue = value; }
        }

        public static double TurnIndicatorValue
        {
            get { return turnIndicatorValue; }
            private set { turnIndicatorValue = value; }
        }

        public static double AirspeedIndicatorValue
        {
            get { return airspeedIndicatorValue; }
            private set { airspeedIndicatorValue = value; }
        }

        public static double VerticalAirspeedIndicatorValue
        {
            get { return verticalAirspeedIndicatorValue; }
            private set { verticalAirspeedIndicatorValue = value; }
        }

        public static double SuctuionGaugeValue
        {
            get { return suctionGaugeValue; }
            private set { suctionGaugeValue = value; }
        }

        public static double TotalFuelValue
        {
            get { return totalFuelValue; }
            private set { totalFuelValue = value; }
        }

        public static double CurrentFuelValue
        {
            get { return currentFuelValue; }
            private set { currentFuelValue = value; }
        }

        public static double AmmeterValue
        {
            get { return ammeterValue; }
            private set { ammeterValue = value; }
        }

        public static double PitchValue
        {
            get { return pitchValue; }
            private set { pitchValue = value; }
        }

        public static double RollValue
        {
            get { return rollValue; }
            private set { rollValue = value; }
        }

        public static double HourValue
        {
            get { return hourValue; }
            private set { hourValue = value; }
        }

        public static double MinuteValue
        {
            get { return minuteValue; }
            private set { minuteValue = value; }
        }

        public static double SecondValue
        {
            get { return secondValue; }
            private set { secondValue = value; }
        }

        private static double ThrottleValue
        {
            get { return throttleValue; }
            set { throttleValue = value; }
        }

        private static double MixtureValue
        {
            get { return mixtureValue; }
            set { mixtureValue = value; }
        }

        private static double TrimWheelValue
        {
            get { return trimWheellValue; }
            set { trimWheellValue = value; }
        }

        // Enumerations for SimConnect requests
        private enum Requests
        {
            Altimeter,
            HeadingIndicator,
            TurnCoordinator,
            TurnIndicator,
            AirspeedIndicator,
            VerticalAirspeedIndicator,
            SuctionGauge,
            TotalFuel,
            CurrentFuel,
            Ammeter,
            Pitch,
            Roll,
            ZuluTime,
            Throttle,
            Mixture,
            BrakeData,
            TrimWheel
        }
        
        // Enumerations for Definitions 
        private enum Definitions
        {
            AltimeterData,
            HeadingIndicatorData,
            TurnCoordinatorData,
            TurnIndicatorData,
            AirspeedIndicatorData,
            VerticalAirspeedIndicatorData,
            SuctionGaugeData,
            TotalFuelData,
            CurrentFuelData,
            AmmeterData,
            PitchData,
            RollData,
            ZuluTimeData,
            ThrottleData,
            MixtureData,
            BrakeData,
            TrimWheelData
        }

        // Custom enum for SimConnect Input Events
        private enum CustomEvents
        {
            THROTTLE_INCREASE = 0,
            THROTTLE_DECREASE = 1,
            MIXTURE_INCREASE = 2,
            MIXTURE_DECREASE = 3,
            BRAKE_TOGGLE = 4,
            TRIM_INCREASE = 5,
            TRIM_DECREASE = 6,
            FLAP_INCREASE = 7,
            FLAP_DECREASE = 8
        }

        public enum SIMCONNECT_NOTIFICATION_GROUP_ID : uint
        {
            Default = 0
        }

        /// <summary>
        /// This method specifies what data the SimConnect Client should expect to recieve
        /// from Microsoft Flight Simulator
        /// </summary>
        /// 
        /// <param name="sender"></param>
        /// <param name="data"></param>
        public static void Simconnect_OnRecvSimobjectData(SimConnect sender, SIMCONNECT_RECV_SIMOBJECT_DATA data)
        {
            // If no simconnection
            if (simconnect == null)
                return;

            // Request Altimeter data. 
            if ((Requests)data.dwRequestID == Requests.Altimeter)
            {
                AltimeterData altimeter = (AltimeterData)data.dwData[0];
                AltimeterValue = altimeter.AltimeterReading; 
                Console.WriteLine($"Altimeter Reading: {altimeter.AltimeterReading} feet");
            }

            // Request Heading Indicator Data
            if ((Requests)data.dwRequestID == Requests.HeadingIndicator)
            {
                HeadingIndicatorData headingindicator = (HeadingIndicatorData)data.dwData[0];
                HeadingIndicatorValue = headingindicator.HeadingIndicatorReading;
                Console.WriteLine($"Heading Indicator Reading: {headingindicator.HeadingIndicatorReading} deg");
            }

            // Request Turn Coordinator data
            if ((Requests)data.dwRequestID == Requests.TurnCoordinator)
            {
                TurnCoordinatorData turncoordinator = (TurnCoordinatorData)data.dwData[0];
                TurnCoordinatorValue = turncoordinator.TurnCoordinatorReading; 
                Console.WriteLine($"Turn Coordinator Reading: {turncoordinator.TurnCoordinatorReading}");
            }

            // Request Turn Indicator data
            if ((Requests)data.dwRequestID == Requests.TurnIndicator)
            {
                TurnIndicatorData turnindicator = (TurnIndicatorData)data.dwData[0];
                TurnIndicatorValue = turnindicator.TurnIndicatorReading;
                Console.WriteLine($"Turn Indicator Reading: {turnindicator.TurnIndicatorReading}");
            }

            // Request Airspeed Indicator Data
            if ((Requests)data.dwRequestID == Requests.AirspeedIndicator)
            {
                AirspeedIndicatorData airspeedindicator = (AirspeedIndicatorData)data.dwData[0];
                AirspeedIndicatorValue = airspeedindicator.AirspeedIndicatorReading;
                Console.WriteLine($"Airspeed Indicator Reading: {airspeedindicator.AirspeedIndicatorReading}");
            }
            
            // Request Vertical Airspeed Indicator Data
            if ((Requests)data.dwRequestID == Requests.VerticalAirspeedIndicator)
            {
                VerticalAirspeedIndicatorData verticalairspeedindicator = (VerticalAirspeedIndicatorData)data.dwData[0];
                VerticalAirspeedIndicatorValue = verticalairspeedindicator.VerticalAirspeedIndicatorReading;
                Console.WriteLine($"Vertical Airspeed Indicator Reading: {verticalairspeedindicator.VerticalAirspeedIndicatorReading}");
            }

            // Request Suction Gauge Data
            if ((Requests)data.dwRequestID == Requests.SuctionGauge)
            {
                SuctionGaugeData suctiongauge = (SuctionGaugeData)data.dwData[0];
                suctionGaugeValue = suctiongauge.SuctionGaugeReading;
                Console.WriteLine($"Suction Gauge Reading (inHg): {suctiongauge.SuctionGaugeReading}");
            }

            // Request Total Fuel Capacity
            if ((Requests)data.dwRequestID == Requests.TotalFuel)
            {
                TotalFuelData totalfuel = (TotalFuelData)data.dwData[0];
                totalFuelValue = totalfuel.TotalFuelReading;
                Console.WriteLine($"Suction Gauge Reading (inHg): {totalfuel.TotalFuelReading}");
            }

            // Request Current Fuel Capacity
            if ((Requests)data.dwRequestID == Requests.CurrentFuel)
            {
                CurrentFuelData currentfuel = (CurrentFuelData)data.dwData[0];
                currentFuelValue = currentfuel.CurrentFuelReading;
                Console.WriteLine($"Suction Gauge Reading (inHg): {currentfuel.CurrentFuelReading}");
            }

            // Request Ammeter Data
            if ((Requests)data.dwRequestID == Requests.Ammeter)
            {
                AmmeterData ammeter = (AmmeterData)data.dwData[0];
                ammeterValue = ammeter.AmmeterReading;
                Console.WriteLine($"Ammeter Reading (amp): {ammeter.AmmeterReading}");
            }

            // Request Pitch Data
            if ((Requests)data.dwRequestID == Requests.Pitch)
            {
                PitchData pitch = (PitchData)data.dwData[0];
                pitchValue = pitch.PitchReading;
                Console.WriteLine($"Pitch Reading (deg): {pitch.PitchReading}");
            }

            // Request Roll Data
            if ((Requests)data.dwRequestID == Requests.Roll)
            {
                RollData roll = (RollData)data.dwData[0];
                rollValue = roll.RollReading;
                Console.WriteLine($"Roll Reading (deg): {roll.RollReading}");
            }

            // Request Clock Data
            if ((Requests)data.dwRequestID == Requests.ZuluTime)
            {
                ZuluTimeData zulutime = (ZuluTimeData)data.dwData[0];
                hourValue = (zulutime.ZuluTimeReading / 3600) % 12;
                minuteValue = (zulutime.ZuluTimeReading / 60) % 60;
                secondValue = zulutime.ZuluTimeReading % 60;
            }

            // Request Throttle Data
            if ((Requests)data.dwRequestID == Requests.Throttle)
            {
                ThrottleData throttleData = (ThrottleData)data.dwData[0];
                ThrottleValue = throttleData.ThrottleReading;
                //Console.WriteLine($"Throttle Reading: {throttleData.ThrottleReading}");
            }

            // Request Mixture Data
            if ((Requests)data.dwRequestID == Requests.Mixture)
            {
                MixtureData mixtureData = (MixtureData)data.dwData[0];
                MixtureValue = mixtureData.MixtureReading;
                
            }

            // Request Trim Wheel Data
            if ((Requests)data.dwRequestID == Requests.TrimWheel)
            {
                // Handle Brake Data if needed
                // Currently not used in this example
                Console.WriteLine("Brake Data Received");
                brakeEnable = true; // Set brake enable to true, if needed for logic
            }
        }

        /// <summary>
        /// This method initializes the process of reading Microsoft Flight Simulator data.
        /// </summary>
        /// <remarks>
        /// Declarations are defined to Simconnect environment variables.
        /// Retrieved data mapped to declared structs (See SimConnectData.cs)
        /// <br/>
        /// TODO: See if refresh rate can be sped up using SIMCONNECT_PERIOD.SIM_FRAME
        /// </remarks>
        public static void InitializeSimReadings()
        {
            // NOTE: Pass Simulation variable as string 
            // in 2nd param in AddToDataDefinition 
            // https://docs.flightsimulator.com/html/Programming_Tools/SimVars/Aircraft_SimVars/Aircraft_System_Variables.htm
            // https://docs.flightsimulator.com/html/Programming_Tools/SimVars/Aircraft_SimVars/Aircraft_Misc_Variables.htm
            // https://docs.flightsimulator.com/html/Programming_Tools/SimVars/Aircraft_SimVars/Aircraft_Fuel_Variables.htm
            // https://docs.flightsimulator.com/html/Programming_Tools/SimVars/Aircraft_SimVars/Aircraft_Electrics_Variables.htm

            if (!ConnectSimconnectClient())
                return;

            // Map events to Simulator Events
            simconnect.MapClientEventToSimEvent(CustomEvents.THROTTLE_INCREASE, "THROTTLE_INCR");
            simconnect.MapClientEventToSimEvent(CustomEvents.THROTTLE_DECREASE, "THROTTLE_DECR");
            simconnect.MapClientEventToSimEvent(CustomEvents.MIXTURE_INCREASE, "MIXTURE_INCR");
            simconnect.MapClientEventToSimEvent(CustomEvents.MIXTURE_DECREASE, "MIXTURE_DECR");

            // https://docs.flightsimulator.com/html/Programming_Tools/Event_IDs/Aircraft_Misc_Events.htm#PARKING_BRAKE_SET
            simconnect.MapClientEventToSimEvent(CustomEvents.BRAKE_TOGGLE, "PARKING_BRAKES");
            simconnect.MapClientEventToSimEvent(CustomEvents.TRIM_INCREASE, "ELEV_UP"); 
            simconnect.MapClientEventToSimEvent(CustomEvents.TRIM_DECREASE, "ELEV_DOWN");

            // https://docs.flightsimulator.com/html/Programming_Tools/Event_IDs/Aircraft_Flight_Control_Events.htm#AXIS_FLAPS_SET
            simconnect.MapClientEventToSimEvent(CustomEvents.FLAP_INCREASE, "FLAPS_INCR");
            simconnect.MapClientEventToSimEvent(CustomEvents.FLAP_DECREASE, "FLAPS_DECR");


            /////////////////////////////////
            // Define and Register Values: //
            /////////////////////////////////

            // Define Altimeter data
            // "Indicated Altitude" - Indicated Altitude in feet
            simconnect.AddToDataDefinition(Definitions.AltimeterData, "INDICATED ALTITUDE", "feet", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);
            simconnect.RegisterDataDefineStruct<AltimeterData>(Definitions.AltimeterData);

            // Define Heading Indicator data
            // "Plane Heading Degrees Gyro" - heading indicator in degrees
            simconnect.AddToDataDefinition(Definitions.HeadingIndicatorData, "PLANE HEADING DEGREES GYRO", "degrees", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);
            simconnect.RegisterDataDefineStruct<HeadingIndicatorData>(Definitions.HeadingIndicatorData);

            // Define Turn Coordinator data
            // "Turn Coordinator Ball" - Turn coordinator reading in degrees
            simconnect.AddToDataDefinition(Definitions.TurnCoordinatorData, "TURN COORDINATOR BALL", "degrees", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);
            simconnect.RegisterDataDefineStruct<TurnCoordinatorData>(Definitions.TurnCoordinatorData);

            // Define Turn Indicator data
            // "TURN INDICATOR RATE"  - Turn Indicator Reading in degrees per second 
            simconnect.AddToDataDefinition(Definitions.TurnIndicatorData, "TURN INDICATOR RATE", "degrees per second", SIMCONNECT_DATATYPE.FLOAT64, 0.0F, SimConnect.SIMCONNECT_UNUSED);
            simconnect.RegisterDataDefineStruct<TurnIndicatorData>(Definitions.TurnIndicatorData);  

            // Define Airspeed Indicator data
            // "Airspeed INDICATED" - Airspeed indicator value on true calibration scale in degrees
            simconnect.AddToDataDefinition(Definitions.AirspeedIndicatorData, "AIRSPEED INDICATED", "Knots", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);
            simconnect.RegisterDataDefineStruct<AirspeedIndicatorData>(Definitions.AirspeedIndicatorData);

            // Define Vertical Airspeed Indicator data
            // "VERTICAL SPEED" - Get vertical speed in feet per second
            simconnect.AddToDataDefinition(Definitions.VerticalAirspeedIndicatorData, "VERTICAL SPEED", "Feet per second", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);
            simconnect.RegisterDataDefineStruct<VerticalAirspeedIndicatorData>(Definitions.VerticalAirspeedIndicatorData);

            // Define Suction Gauge data
            simconnect.AddToDataDefinition(Definitions.SuctionGaugeData, "SUCTION PRESSURE", "Feet per second", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);
            simconnect.RegisterDataDefineStruct<SuctionGaugeData>(Definitions.SuctionGaugeData);

            // Define Total Fuel data (How much fuel the aircraft can hold)
            // "FUEL TOTAL CAPACITY" - Get total capacity of all fuel tanks in gallons
            simconnect.AddToDataDefinition(Definitions.TotalFuelData, "FUEL TOTAL CAPACITY", "Gallons", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);
            simconnect.RegisterDataDefineStruct<TotalFuelData>(Definitions.TotalFuelData);

            // Define Current Fuel Data (How much fuel the aircraft has left)
            // "FUEL TOTAL QUANTITY" - Current total quantity of fuel left in all tanks (gal)
            simconnect.AddToDataDefinition(Definitions.CurrentFuelData, "FUEL TOTAL QUANTITY", "Gallons", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);
            simconnect.RegisterDataDefineStruct<CurrentFuelData>(Definitions.CurrentFuelData);

            // Define Ammeter value
            // "ELECTRICAL BATTERY BUS AMPS" - Get Battery bus current in Amperes
            simconnect.AddToDataDefinition(Definitions.AmmeterData, "ELECTRICAL BATTERY BUS AMPS", "Amperes", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);
            simconnect.RegisterDataDefineStruct<AmmeterData>(Definitions.AmmeterData);

            // Define Pitch value
            // "ALTITUDE INDICATOR PITCH DEGREES" - Get pitch value in degrees
            simconnect.AddToDataDefinition(Definitions.PitchData, "ATTITUDE INDICATOR PITCH DEGREES", "degrees", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);
            simconnect.RegisterDataDefineStruct<PitchData>(Definitions.PitchData);

            // Define Roll value
            simconnect.AddToDataDefinition(Definitions.RollData, "ATTITUDE INDICATOR BANK DEGREES", "degrees", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);
            simconnect.RegisterDataDefineStruct<RollData>(Definitions.RollData);

            // Define Zulu Time value
            //https://docs.flightsimulator.com/html/Programming_Tools/Environment_Variables.htm?rhhlterm=zulu%20time&rhsearch=zulu%20time
            simconnect.AddToDataDefinition(Definitions.ZuluTimeData, "LOCAL TIME", "seconds", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);
            simconnect.RegisterDataDefineStruct<ZuluTimeData>(Definitions.ZuluTimeData);

            // Define Throttle value
            simconnect.AddToDataDefinition(Definitions.ThrottleData, "GENERAL ENG THROTTLE LEVER POSITION:1", "Percent", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);
            simconnect.RegisterDataDefineStruct<ThrottleData>(Definitions.ThrottleData);

            // Define Mixture value
            simconnect.AddToDataDefinition(Definitions.MixtureData, "GENERAL ENG MIXTURE LEVER POSITION:1", "Percent", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);
            simconnect.RegisterDataDefineStruct<MixtureData>(Definitions.MixtureData);

            

            /////////////////////
            // Request Values: //
            /////////////////////

            // Request Altimeter value
            simconnect.RequestDataOnSimObject(Requests.Altimeter, Definitions.AltimeterData, SimConnect.SIMCONNECT_OBJECT_ID_USER, SIMCONNECT_PERIOD.SECOND, SIMCONNECT_DATA_REQUEST_FLAG.DEFAULT, 0, 0, 0);

            // Register Heading Indicator Request
            simconnect.RequestDataOnSimObject(Requests.HeadingIndicator, Definitions.HeadingIndicatorData, SimConnect.SIMCONNECT_OBJECT_ID_USER, SIMCONNECT_PERIOD.SECOND, SIMCONNECT_DATA_REQUEST_FLAG.DEFAULT, 0, 0, 0);

            // Request Turn Coordinator value
            simconnect.RequestDataOnSimObject(Requests.TurnCoordinator, Definitions.TurnCoordinatorData, SimConnect.SIMCONNECT_OBJECT_ID_USER, SIMCONNECT_PERIOD.SECOND, SIMCONNECT_DATA_REQUEST_FLAG.DEFAULT, 0, 0, 0);

            // Request Turn Indicator value
            simconnect.RequestDataOnSimObject(Requests.TurnIndicator, Definitions.TurnIndicatorData, SimConnect.SIMCONNECT_OBJECT_ID_USER, SIMCONNECT_PERIOD.SECOND, SIMCONNECT_DATA_REQUEST_FLAG.DEFAULT, 0, 0, 0);

            // Request Airspeed Indicator value
            simconnect.RequestDataOnSimObject(Requests.AirspeedIndicator, Definitions.AirspeedIndicatorData, SimConnect.SIMCONNECT_OBJECT_ID_USER, SIMCONNECT_PERIOD.SECOND, SIMCONNECT_DATA_REQUEST_FLAG.DEFAULT, 0, 0, 0);

            // Request Vertical Airspeed Indicator value
            simconnect.RequestDataOnSimObject(Requests.VerticalAirspeedIndicator, Definitions.VerticalAirspeedIndicatorData, SimConnect.SIMCONNECT_OBJECT_ID_USER, SIMCONNECT_PERIOD.SECOND, SIMCONNECT_DATA_REQUEST_FLAG.DEFAULT, 0, 0, 0);

            // Request Suction Gauge value
            simconnect.RequestDataOnSimObject(Requests.SuctionGauge, Definitions.SuctionGaugeData, SimConnect.SIMCONNECT_OBJECT_ID_USER, SIMCONNECT_PERIOD.SECOND, SIMCONNECT_DATA_REQUEST_FLAG.DEFAULT, 0, 0, 0);

            // Request Total Fuel Capacity value
            simconnect.RequestDataOnSimObject(Requests.TotalFuel, Definitions.TotalFuelData, SimConnect.SIMCONNECT_OBJECT_ID_USER, SIMCONNECT_PERIOD.SECOND, SIMCONNECT_DATA_REQUEST_FLAG.DEFAULT, 0, 0, 0);

            // Request Current Fuel Capacity value
            simconnect.RequestDataOnSimObject(Requests.CurrentFuel, Definitions.CurrentFuelData, SimConnect.SIMCONNECT_OBJECT_ID_USER, SIMCONNECT_PERIOD.SECOND, SIMCONNECT_DATA_REQUEST_FLAG.DEFAULT, 0, 0, 0);
           
            // Request Ammeter Value
            simconnect.RequestDataOnSimObject(Requests.Ammeter, Definitions.AmmeterData, SimConnect.SIMCONNECT_OBJECT_ID_USER, SIMCONNECT_PERIOD.SECOND, SIMCONNECT_DATA_REQUEST_FLAG.DEFAULT, 0, 0, 0);

            // Request Pitch Value
            simconnect.RequestDataOnSimObject(Requests.Pitch, Definitions.PitchData, SimConnect.SIMCONNECT_OBJECT_ID_USER, SIMCONNECT_PERIOD.SECOND, SIMCONNECT_DATA_REQUEST_FLAG.DEFAULT, 0, 0, 0);

            // Request Roll Value
            simconnect.RequestDataOnSimObject(Requests.Roll, Definitions.RollData, SimConnect.SIMCONNECT_OBJECT_ID_USER, SIMCONNECT_PERIOD.SECOND, SIMCONNECT_DATA_REQUEST_FLAG.DEFAULT, 0, 0, 0);

            // Request Clock
            simconnect.RequestDataOnSimObject(Requests.ZuluTime, Definitions.ZuluTimeData, SimConnect.SIMCONNECT_OBJECT_ID_USER, SIMCONNECT_PERIOD.SECOND, SIMCONNECT_DATA_REQUEST_FLAG.DEFAULT, 0, 0, 0);

            

            //////////////////////////////////////////////////////
            ///NOTE:  The throttle periiod is every Sim_Frame ////
            //////////////////////////////////////////////////////
            // Request Throttle Value
            simconnect.RequestDataOnSimObject(Requests.Throttle, Definitions.ThrottleData, SimConnect.SIMCONNECT_OBJECT_ID_USER, SIMCONNECT_PERIOD.SIM_FRAME, SIMCONNECT_DATA_REQUEST_FLAG.DEFAULT, 0, 0, 0);

            //Request Mixture Value
            simconnect.RequestDataOnSimObject(Requests.Mixture, Definitions.MixtureData, SimConnect.SIMCONNECT_OBJECT_ID_USER, SIMCONNECT_PERIOD.SIM_FRAME, SIMCONNECT_DATA_REQUEST_FLAG.DEFAULT, 0, 0, 0);

            // Register Simconnect OnRecvSimobjectData event
            simconnect.OnRecvSimobjectData += Simconnect_OnRecvSimobjectData;

            // Recieve SimConnect data.
            simconnect.ReceiveMessage();


            // Indicate readings initialized
            readingsInitialized = true;
        }


        /// <summary>
        /// Attempt to create an instance of SimConnect client.
        /// </summary>
        /// <returns>
        /// bool - True/False if SimConnect Client could be established
        /// </returns>
        public static bool ConnectSimconnectClient()
        {
            // Attempt to create instance of SimConnect if no instance found
            if (simconnect == null)
            {
                try
                {
                    // Open SimConnect client
                    simconnect = new SimConnect("Managed Data Request", windowHandle, WM_USER_SIMCONNECT, null, 0);

                    // Map Simconnect events upon successful SimConnect Connection
                    simconnect.OnRecvSimobjectData += Simconnect_OnRecvSimobjectData;

                    connectionStatus = true;
                    return true;
                }
                catch (COMException ex) // Simconnect instance can not be created
                {

                    Console.WriteLine($"SimConnect Connection failed: {ex.Message}");
                    return false;
                }
            }
            else // If Simconnect instance already found (App is already connected to simconnect)
            {
                return true;
            }
        }

        /// <summary>
        /// Disconnect SimConnect Client from MSFS
        /// </summary>
        public static bool DisconnectSimconnectClient()
        {
            // Dispose if instance of simconnect != null
            if (simconnect != null)
            {
                simconnect.Dispose();
                simconnect = null;
            }
            connectionStatus = false;
            readingsInitialized = false;


            return true;
        }

        /// <summary>
        /// Refresh values retrieved from SimConnect
        /// </summary>
        /// <remarks>
        /// This method should called on each timer itteration of Form objects
        /// Returns true if successful, returns false if exception thrown
        /// </remarks>
        public static bool RefreshSimconnect()
        {
            if(simconnect != null)
            {
                try
                {
                    simconnect.ReceiveMessage();
                    return true;

                }
                catch(COMException ex) 
                {
                    // Handle exception
                    DisconnectSimconnectClient();

                    Console.WriteLine($"SimConnect Refresh failed: {ex.Message}");
                    return false;
                }
            }
            return false;
        }


        /// <summary>
        /// Update MSFS Throttle from Arduino Potentiometer value 
        /// (Range: 0-1023)
        /// </summary>
        /// <param name="potValue"></param>
        public static void UpdateThrottleFromPotentiometer(int potValue)
        {
            // Map potentiometer value (0-1023) to desired throttle percentage (0-100)
            double desiredThrottlePercentage = (potValue / 1023.0) * 100.0;
            
            // Read the current throttle percentage (assumed already updated via SimConnect)
            double currentThrottlePercentage = ThrottleValue;

            double tolerance = 5.0;

            // Speed the change in values will  update
            int speed = 5;

            for (int i = 0; i < speed; i++)
            {

                // Return if throttle within 5% to avoid jittering
                if (Math.Abs(currentThrottlePercentage - desiredThrottlePercentage) < tolerance)
                {
                    return;
                }

                // If the current throttle is less than desired, simulate throttle increase
                if (currentThrottlePercentage < desiredThrottlePercentage)
                {
                    //Console.WriteLine("\n\nCurrent < Desired\n\n");
                    simconnect.TransmitClientEvent(SimConnect.SIMCONNECT_OBJECT_ID_USER,
                        CustomEvents.THROTTLE_INCREASE, 0, SIMCONNECT_NOTIFICATION_GROUP_ID.Default, SIMCONNECT_EVENT_FLAG.GROUPID_IS_PRIORITY);
                }

                // If the current throttle is greater than desired, simulate throttle decrease
                else if (currentThrottlePercentage > desiredThrottlePercentage)
                {

                    simconnect.TransmitClientEvent(SimConnect.SIMCONNECT_OBJECT_ID_USER,
                        CustomEvents.THROTTLE_DECREASE, 0, SIMCONNECT_NOTIFICATION_GROUP_ID.Default, SIMCONNECT_EVENT_FLAG.GROUPID_IS_PRIORITY);
                }
            }
        }

        /// <summary>
        /// Update MSFS Mixture from Arduino Potentiometer reading
        /// </summary>
        /// <param name="potValue"></param>
        public static void UpdateMixtureFromPotentiometer(int potValue)
        {
            // Map potentiometer value (0-1023) to desired throttle percentage (0-100)
            double desiredMixturePercentage = (potValue / 1023.0) * 100.0;

            // Read the current throttle percentage (assumed already updated via SimConnect)
            double currentMixturePercentage = MixtureValue;

            double tolerance = 5.0;

            int speed = 3;

            for (int i = 0; i < speed; i++)
            {

                // Return if throttle within 5% to avoid jittering
                if (Math.Abs(currentMixturePercentage - desiredMixturePercentage) < tolerance)
                {
                    return;
                }

                // If the current throttle is less than desired, simulate throttle increase
                if (currentMixturePercentage < desiredMixturePercentage)
                {
                    //Console.WriteLine("\n\nCurrent < Desired\n\n");
                    simconnect.TransmitClientEvent(SimConnect.SIMCONNECT_OBJECT_ID_USER,
                        CustomEvents.MIXTURE_INCREASE, 0, SIMCONNECT_NOTIFICATION_GROUP_ID.Default, SIMCONNECT_EVENT_FLAG.GROUPID_IS_PRIORITY);
                }
                // If the current throttle is greater than desired, simulate throttle decrease
                else if (currentMixturePercentage > desiredMixturePercentage)
                {
                    //Console.WriteLine("\n\nCurrent > Desired\n\n");
                    simconnect.TransmitClientEvent(SimConnect.SIMCONNECT_OBJECT_ID_USER,
                        CustomEvents.MIXTURE_DECREASE, 0, SIMCONNECT_NOTIFICATION_GROUP_ID.Default, SIMCONNECT_EVENT_FLAG.GROUPID_IS_PRIORITY);
                }
            }
        }
        /// <summary>
        /// Toggle the Parking Brake in MSFS based on potentiometer value
        /// </summary>
        /// <param name="potValue"></param>
        public static void UpdateBrakeFromPotentiometer(int potValue)
        {
            // If potentiometer is high, Toggle brake status and brakeEnable debounce.
            if (potValue > 923 && brakeEnable == false)
            {
                brakeEnable = true;
                simconnect.TransmitClientEvent(SimConnect.SIMCONNECT_OBJECT_ID_USER, 
                    CustomEvents.BRAKE_TOGGLE, 0, SIMCONNECT_NOTIFICATION_GROUP_ID.Default, SIMCONNECT_EVENT_FLAG.GROUPID_IS_PRIORITY);
            }

            // If potentiometer is low, toggle brake status and brakeEnable debounce.
            else if (potValue < 100 && brakeEnable == true)
            {
                brakeEnable = false;
                simconnect.TransmitClientEvent(SimConnect.SIMCONNECT_OBJECT_ID_USER, 
                    CustomEvents.BRAKE_TOGGLE, 0, SIMCONNECT_NOTIFICATION_GROUP_ID.Default, SIMCONNECT_EVENT_FLAG.GROUPID_IS_PRIORITY);
            }
        }

        /// <summary>
        /// Update the trim wheel
        /// Toggles calibration of yoke pich. Does not directly affect trim wheel in MSFS, but should get the same result. 
        /// </summary>
        /// <param name="potValue"></param>
        public static void UpdateTrimWheelFromPotentiometer(int potValue)
        {
            // Define the center and deadband threshold
            const int center = 512;
            const int deadband = 100; // Values within ±100 of center are ignored

            int speed = 3;

            for (int i = 0; i < speed; i++)
            {
                // If within the deadband, do nothing
                if (Math.Abs(potValue - center) < deadband)
                {
                    return;
                }

                // If the potentiometer reading is above center, send a TRIM_INCREASE event.
                if (potValue > center)
                {
                    simconnect.TransmitClientEvent(SimConnect.SIMCONNECT_OBJECT_ID_USER,
                        CustomEvents.TRIM_INCREASE, 0, SIMCONNECT_NOTIFICATION_GROUP_ID.Default, SIMCONNECT_EVENT_FLAG.GROUPID_IS_PRIORITY);
                }
                // Otherwise, if it's below center, send a TRIM_DECREASE event.
                else
                {
                    simconnect.TransmitClientEvent(SimConnect.SIMCONNECT_OBJECT_ID_USER,
                        CustomEvents.TRIM_DECREASE, 0, SIMCONNECT_NOTIFICATION_GROUP_ID.Default, SIMCONNECT_EVENT_FLAG.GROUPID_IS_PRIORITY);
                }
            }
        }


        // Potentiometer reading will be 350-450 for 30
        // >450 =< 520 for 20 deg
        // 521 - 620 for 10 
        // anything higher should be 0 
        public static void UpdateFlapsFromPotentiometer(int potValue)
        {

            Console.WriteLine("\n\nUpdating Flaps from Potentiometer: " + potValue + "\n\n");
            // Map the 0-1023 range to three flap positions:
            // 0 <= potValue < 341  => Flaps Up (position 0)
            // 341 <= potValue < 682 => Takeoff flaps (position 1)
            // 682 <= potValue <= 1023 => Landing flaps (position 2)
            int desiredFlapPosition;
            if (potValue >= 30)
            {
                desiredFlapPosition = 3; // 30 
            }
            else if (potValue >= 20)
            {
                desiredFlapPosition = 2;
            }
            else if (potValue >= 10)
            {
                desiredFlapPosition = 1;
            }
            else
            {
                desiredFlapPosition = 0; // 30
            }

            // Compare with the current flap position and adjust if needed
            if (desiredFlapPosition > flapSwitchValue)
            {
                // Increase flaps by one step
                simconnect.TransmitClientEvent(SimConnect.SIMCONNECT_OBJECT_ID_USER,
                    CustomEvents.FLAP_INCREASE, 0, SIMCONNECT_NOTIFICATION_GROUP_ID.Default, SIMCONNECT_EVENT_FLAG.GROUPID_IS_PRIORITY);

                flapSwitchValue++;
            }
            else if (desiredFlapPosition < flapSwitchValue)
            {
                // Decrease flaps by one step
                simconnect.TransmitClientEvent(SimConnect.SIMCONNECT_OBJECT_ID_USER,
                    CustomEvents.FLAP_DECREASE, 0, SIMCONNECT_NOTIFICATION_GROUP_ID.Default, SIMCONNECT_EVENT_FLAG.GROUPID_IS_PRIORITY);

                flapSwitchValue--;
            }
            // If desiredFlapPosition equals currentFlapPosition, do nothing.
        }

        public static UtilityForm UtilityForm
        {
            get => default;
            set
            {
            }
        }

        public static DevForm DevForm
        {
            get => default;
            set
            {
            }
        }
    }
}
