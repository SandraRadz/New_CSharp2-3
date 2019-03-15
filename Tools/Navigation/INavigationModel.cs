namespace KMA.ProgrammingInCSharp2019.Practice5.Navigation.Tools.Navigation
{
    internal enum ViewType
    {
        SignIn,
        SignUp,
        Main
    }

    interface INavigationModel
    {
        void Navigate(ViewType viewType);
    }
}
