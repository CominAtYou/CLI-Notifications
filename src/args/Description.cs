using Microsoft.Toolkit.Uwp.Notifications;

namespace Program {
    namespace Args {
        class Description {
            public static ToastContentBuilder addDescription(ToastContentBuilder builder, string[] args) {
                return builder.AddText(Notifications.createTextElement(args, "--description"));
            }
        }
    }
}
