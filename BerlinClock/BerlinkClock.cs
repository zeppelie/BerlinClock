namespace BerlinClock
{
    public static class BerlinkClock
    {
        private const char RedLamp = 'R';
        private const char OffLamp = 'O';
        private const char YellowLamp = 'Y';

        public static string SingleMinuteRow(string input)
        {
            int.TryParse(input, out var minutes);
            var rest = minutes % 5;

            var result = FillRow(rest, YellowLamp);

            return result;
        }

        public static string FiveMinuteRow(string input)
        {
            var result = string.Empty;
            int.TryParse(input, out var minutes);
            var fiveMinutes = minutes / 5;

            for (var i = 0; i < fiveMinutes; i++)
                result += (i + 1) % 3 == 0 ? RedLamp : YellowLamp;

            for (var j = 11; j > fiveMinutes; j--)
                result += OffLamp;

            return result;
        }

        public static string SingleHourRow(string input)
        {
            int.TryParse(input, out var hours);
            var rest = hours % 5;

            var result = FillRow(rest, RedLamp);

            return result;
        }

        public static string FiveHourRow(string input)
        {
            int.TryParse(input, out var hours);
            var fiveHours = hours / 5;

            var result = FillRow(fiveHours, RedLamp);

            return result;
        }

        public static string SingleSecondLamp(string input)
        {
            int.TryParse(input, out var seconds);
            var rest = seconds % 2;

            var result = rest == 0 ? YellowLamp.ToString() : OffLamp.ToString();

            return result;
        }

        public static string Convert(string[] clockTime)
        {
            var hours = clockTime[0];
            var minutes = clockTime[1];
            var seconds = clockTime[2];
            var result = SingleSecondLamp(seconds) + FiveHourRow(hours) + SingleHourRow(hours) +
                         FiveMinuteRow(minutes) + SingleMinuteRow(minutes);

            return result;
        }
        
        private static string FillRow(int onLampsNumber, char onLampColor)
        {
            var result = string.Empty;
            for (var i = 0; i < onLampsNumber; i++)
                result += onLampColor;

            for (var j = 4; j > onLampsNumber; j--)
                result += OffLamp;
            
            return result;
        }
    }
}