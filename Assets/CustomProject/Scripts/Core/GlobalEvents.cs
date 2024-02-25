using UnityEngine;

namespace CustomProject
{
    public static class GlobalEvents
    {
        // Events
        public static OnGuidSelected OnGuideSelected { get; } = new OnGuidSelected();
        public static OnMeditationTimeSelected OnMeditationTimeSelected { get; } = new OnMeditationTimeSelected();
 

        // UI Commands
        public static GoToStartScreen GoToStartScreen { get; } = new GoToStartScreen();
        public static GoToLoginScreen GoToLoginScreen { get; } = new GoToLoginScreen();
        public static GoToWelcomeToInnerScreen GoToWelcomeToInnerScreen { get; } = new GoToWelcomeToInnerScreen();
        public static GoToSignUpScreen GoToSignUpScreen { get; } = new GoToSignUpScreen();
        public static GoToOnboardingScreen GoToOnboardingScreen { get; } = new GoToOnboardingScreen();
        public static GoToFeelingsScreen GoToFeelingsScreen { get; } = new GoToFeelingsScreen();
        public static GoToTimeSetupScreen GoToTimeSetupScreen { get; } = new GoToTimeSetupScreen();
        public static GoToConditionScreen GoToConditionScreen { get; } = new GoToConditionScreen();
        public static GoToCheckMeditationScreen GoToCheckMeditationScreen { get; } = new GoToCheckMeditationScreen();
        public static GoToMeditationStyleScreen GoToMeditationStyleScreen { get; } = new GoToMeditationStyleScreen();
        public static GoToMyMeditationsScreen GoToMyMeditationsScreen { get; } = new GoToMyMeditationsScreen();
        public static GoToPlayingMeditationScreen GoToPlayingMeditationScreen { get; } = new GoToPlayingMeditationScreen();
    }

    public class OnGuidSelected : AppGlobalEvent<string> { }
    public class OnMeditationTimeSelected : AppGlobalEvent<float> { }
    public class GoToStartScreen : AppGlobalEvent { }
    public class GoToLoginScreen : AppGlobalEvent { }
    public class GoToWelcomeToInnerScreen : AppGlobalEvent { }
    public class GoToSignUpScreen : AppGlobalEvent { }
    public class GoToOnboardingScreen : AppGlobalEvent { }
    public class GoToFeelingsScreen : AppGlobalEvent { }
    public class GoToTimeSetupScreen : AppGlobalEvent { }
    public class GoToConditionScreen : AppGlobalEvent { }
    public class GoToCheckMeditationScreen : AppGlobalEvent { }
    public class GoToMeditationStyleScreen : AppGlobalEvent { }
    public class GoToMyMeditationsScreen : AppGlobalEvent { }
    public class GoToPlayingMeditationScreen : AppGlobalEvent { }
}
