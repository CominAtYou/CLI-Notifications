#pragma warning disable CS8600

using Microsoft.Toolkit.Uwp.Notifications;

namespace Program {
    namespace Args {
        class Image {
            public static ToastContentBuilder setImage(ToastContentBuilder builder, string[] args) {
                if (Array.IndexOf(args, "--image") == args.Length - 1) {
                    Console.Error.WriteLine("No value provided for argument '--image'!");
                    Environment.Exit(3);
                }

                Uri uri = null;

                try {
                    uri = new Uri(args[Array.IndexOf(args, "--image") + 1]);
                }
                catch {
                    Console.Error.WriteLine("Invalid URI provided for avatar!");
                    Environment.Exit(3);
                }

                return builder.AddInlineImage(uri);
            }
        }
    }
}
