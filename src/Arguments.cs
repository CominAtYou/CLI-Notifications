namespace Program {
    class Arguments {
        public static void verify(List<string> argsList) {
            // Ensure the command includes a title.
            if (!argsList.Contains("--title") || argsList.IndexOf("--title") == argsList.Count - 1) {
                Console.Error.WriteLine("Required arguments are either missing or invalid!");
                Environment.Exit(3);
            }

            if (argsList.Contains("--description") && argsList.IndexOf("--description") == argsList.Count - 1) {
                Console.Error.WriteLine("Invalid value provided for description parameter!");
                Environment.Exit(3);
            }
        }
    }
}
