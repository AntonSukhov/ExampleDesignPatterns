namespace ExampleDesignPatterns.Behavioral.Memento;

public static class Client
{
    public static void Run()
    {
        IEditor editor = new Editor();
        IMementoHistory mementoHistory = new MementoHistory();

        //Определение начального состояния редактора:
        editor.Text = $"{Environment.CurrentDirectory}";
        editor.Display();

        //Создаю хранилище редактора, сохраняю в нем текущее состояние (значение поля Text) редактора и
        //сохраняю хранилище.
        mementoHistory.Save(editor.CreateMemento());

        //Вношу изменение в состояние редактора
        editor.Text = $"{Environment.OSVersion}";
        editor.Display();

        //Хочу откатить последнее изменение на предыдущее значение состояния редактора:
        var memento = mementoHistory.Undo() as IEditorMemento;

        if (memento != null)
            editor.Restore(memento);
        else
            Console.WriteLine("В истории хранилищ отсутствует хранилище");

        editor.Display();

    }
}
