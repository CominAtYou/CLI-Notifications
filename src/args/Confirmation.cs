using Microsoft.Toolkit.Uwp.Notifications;

namespace Program {
    namespace Args {
        class Confirmation {
            public static ToastContentBuilder addButtons(ToastContentBuilder builder, string[] args) {
                return builder.AddButton(new ToastButton()
                    .SetContent("Yes")
                    .AddArgument("action", "positiveSelection")
                )
                .AddButton(new ToastButton()
                    .SetContent("No")
                    .AddArgument("action", "negativeSelection")
                );
            }
        }
    }
}
