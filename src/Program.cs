using Microsoft.Toolkit.Uwp.Notifications;

namespace Program {
    class Program {
        static void Main(string[] args) {
            Arguments.runUtilityArguments(args);
            Arguments.verify(args);

            bool wantsConfirmation = args.Contains("--confirmation");
            bool wantsClickableWithoutConfirmation = !wantsConfirmation && args.Contains("--clickable");

            ToastContentBuilder notification = Arguments.apply(new ToastContentBuilder(), args);

            ToastNotificationManagerCompat.OnActivated += Notifications.onActivated(wantsConfirmation);

            notification.Show();

            if (wantsConfirmation || wantsClickableWithoutConfirmation) while(true) { continue; } // Keep the app from closing until notification is interacted with
        }
    }
}
