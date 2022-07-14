using Microsoft.Toolkit.Uwp.Notifications;

namespace Program {
    class Notifications {
        public static string createTextElement(List<string> argsList, string delimiter) {
            if (!delimiter.StartsWith("--")) throw new ArgumentException("Delimiter must start with \"--\"");
            if (argsList.IndexOf(delimiter) == argsList.Count - 1) throw new ArgumentException("Delimiter does not have any arguments!");

            string title = "";
            for (int i = argsList.IndexOf(delimiter) + 1; i < argsList.Count; i++) { // This is needed because args is space-delimited
                if (argsList[i].StartsWith("--")) break; // Stop when another argument is reached
                title += " " + argsList[i];
            }
            return title;
        }
    }
}
