namespace WindowsFormsApp1
{

    
    public static class Logger
    {
        
         public static void LogError(string message)
         {
            Main form = Program.inizializedMain;
            form.LogSendMessage("Error: " + message);
         }
        public static void LogMessage(string message)
        {
            Main form = Program.inizializedMain;
            form.LogSendMessage("Message:: " + message);
        }
    }
}