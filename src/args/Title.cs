using Microsoft.Toolkit.Uwp.Notifications;

namespace Program {
    namespace Args {
        class Title {
            public static ToastContentBuilder addTitle(ToastContentBuilder builder, string[] args) {
                return builder.AddText(Notifications.createTextElement(args, "--title"));
            }
        }
    }
}
