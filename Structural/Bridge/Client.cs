namespace ExampleDesignPatterns.Structural.Bridge;

/// <summary>
/// Клиент использует паттерн Bridge:
/// - Context (WindowBase) определяет поведение окна (модальное, диалоговое).
/// - Implementator (ThemeImplementorBase) определяет тему оформления (светлая, тёмная).
/// 
/// Эти две оси независимы и могут комбинироваться:
/// ModalWindow + LightThemeImplementor
/// ModalWindow + DarkThemeImplementor
/// DialogWindow + LightThemeImplementor
/// DialogWindow + DarkThemeImplementor
/// </summary>
public static class Client
{
    public static void Run()
    {
        // Модальное окно со светлой темой
        WindowBase modalLightWindow = new ModalWindow(new LightThemeImplementor());
        modalLightWindow.Show();
    }
}
