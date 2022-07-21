#pragma warning disable CS8600

using Microsoft.Toolkit.Uwp.Notifications;

namespace Program {
    namespace Args {
        class Avatar {
            public static ToastContentBuilder setAvatar(ToastContentBuilder builder, string[] args) {
                if (Array.IndexOf(args, "--avatar") == args.Length - 1) {
                    Console.Error.WriteLine("No value provided for argument '--avatar'!");
                    Environment.Exit(3);
                }

                Uri uri = null;

                try {
                    uri = new Uri(args[Array.IndexOf(args, "--avatar") + 1]);
                }
                catch {
                    Console.Error.WriteLine("Invalid URI provided for avatar!");
                    Environment.Exit(3);
                }

                return builder.AddAppLogoOverride(uri, ToastGenericAppLogoCrop.Circle);
            }
        }
    }
}
