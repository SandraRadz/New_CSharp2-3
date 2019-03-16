namespace KMA.ProgrammingInCSharp2019.Practice5.Navigation.Tools.Navigation
{
    internal enum ViewType
    {
        Start,
        Result
    }

    interface INavigationModel
    {
        void Navigate(ViewType viewType);
    }
}
