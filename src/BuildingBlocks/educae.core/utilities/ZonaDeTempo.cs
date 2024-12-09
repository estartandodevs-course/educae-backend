namespace educae.core.utilities
{
    public static class ZonaDeTempo
    {
        public static TimeZoneInfo ObterZonaDeTempo()
        {
            TimeZoneInfo cetZone;

            try
            {
                cetZone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
            }
            catch
            {
                cetZone = TimeZoneInfo.FindSystemTimeZoneById("America/Sao_Paulo");
            }

            return cetZone;
        }
    }
}