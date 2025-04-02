
/**********************************************************************************
 *  Author          :   Jason Broom
 *  Course Number   :   STG-452
 *  Last Revision   :   2/23/25
 *  Class           :   SimConnectUtility.cs
 *  Description     :   This module defines various structs to parse data read
 *                      from the SimConnect Client in the FlightSimCapstone
 *                      namespace. (See SimConnectUtility.cs)
 **********************************************************************************
 * I used source code from the following websites to complete
 * this assignment:
 * 
 * SimConnect Struct Requirements:
 * https://docs.flightsimulator.com/html/Programming_Tools/SimConnect/Programming_SimConnect_Clients_using_Managed_Code.htm
 */


namespace FlightSimCapstone
{
    /// <summary>
    /// Struct for Altimeter data
    /// </summary>
    struct AltimeterData
    {
        public double AltimeterReading; // Altimeter value in feet
    }
    
    /// <summary>
    /// Struct for Heading Indicator data
    /// </summary>
    struct HeadingIndicatorData
    {
        public double HeadingIndicatorReading; // Heading Indicator value in degrees
    }

    /// <summary>
    /// Struct for Turn Coordinator data
    /// </summary>
    struct TurnCoordinatorData
    {
        public double TurnCoordinatorReading;
    }

    /// <summary>
    /// Struct for Turn Indicator data
    /// </summary>
    struct TurnIndicatorData
    {
        public double TurnIndicatorReading;
    }

    /// <summary>
    /// Struct for Airspeed Indicator data
    /// </summary>
    struct AirspeedIndicatorData
    {
        public double AirspeedIndicatorReading;
    }

    /// <summary>
    /// Struct for Airspeed Indicator data
    /// </summary>
    struct VerticalAirspeedIndicatorData
    {
        public double VerticalAirspeedIndicatorReading;
    }

    /// <summary>
    /// Struct for Suction Gauge data
    /// </summary>
    struct SuctionGaugeData
    {
        public double SuctionGaugeReading;
    }

    /// <summary>
    /// Struct for Total Fuel data
    /// </summary>
    struct TotalFuelData
    {
        public double TotalFuelReading; 
    }

    /// <summary>
    /// Struct for Current Fuel data
    /// </summary>
    struct CurrentFuelData
    {
        public double CurrentFuelReading;
    }

    /// <summary>
    /// Struct for Ammeter data
    /// </summary>
    struct AmmeterData
    {
        public double AmmeterReading;
    }

    /// <summary>
    /// Struct for Pitch Data
    /// </summary>
    struct PitchData
    {
        public double PitchReading;
    }

    /// <summary>
    /// Struct for Roll Data
    /// </summary>
    struct RollData
    {
        public double RollReading;
    }

    /// <summary>
    /// Struct for Hour Data
    /// </summary>
    struct ZuluTimeData
    {
        public double ZuluTimeReading;
    }


    struct AttitudeIndicatorCalibation
    {
        public double PitchCalibration;
    }


    struct ThrottleData
    {
        public double ThrottleReading;
    }

    struct MixtureData
    {
        public double MixtureReading;
    }   
}
