using System;

namespace Document
{
    class DocumentWorker
    {
        public virtual void OpenDocument()
        {
            Console.WriteLine("Документ открыт");
        }
 
        public virtual void EditDocument()
        {
            Console.WriteLine("Редактирование документа доступно в версии Про");
        }
 
        public virtual void SaveDocument()
        {
            Console.WriteLine("Сохранение документа доступно в версии Про");
        }
    }
    class ProDocumentWorker : DocumentWorker
    {
        public override void EditDocument()
        {
            Console.WriteLine("Документ отредактирован");
        }
 
        public override void SaveDocument()
        {
            Console.WriteLine("Документ сохранен в старом формате, сохранение в остальных форматах доступно в версии Эксперт");
        }
    }
    class ExpertDocumentWorker : ProDocumentWorker
    {
        public override void SaveDocument()
        {
            Console.WriteLine("Документ сохранен в новом формате");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            const string proKey = "pro";
            const string expKey = "exp";
            Console.WriteLine("Введите лицензионный ключ!");
            string key = Console.ReadLine();
            DocumentWorker document = new DocumentWorker();
            switch (key)
            {
                case proKey: document = new ProDocumentWorker(); break;
                case expKey: document = new ExpertDocumentWorker(); break;
                default: document = new DocumentWorker(); break;
            }
            Console.WriteLine("Введите команды для работы с документом: \n1-Открыть документ, \n2-Редактировать документ, \n3-Сохранить, \n4-выход");
            bool b = true;
            while (b == true)
            {
                switch (Console.ReadLine())
                {
                    case "1":  Console.ForegroundColor = ConsoleColor.Green; document.OpenDocument(); Console.ForegroundColor = ConsoleColor.White; break;
                    case "2": Console.ForegroundColor = ConsoleColor.Green; document.EditDocument(); Console.ForegroundColor = ConsoleColor.White; break;
                    case "3": Console.ForegroundColor = ConsoleColor.Green; document.SaveDocument(); Console.ForegroundColor = ConsoleColor.White; break;
                    case "4": b =false; Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Выход"); Console.ForegroundColor = ConsoleColor.White; break;
                    default :Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Неправильная команда!"); Console.ForegroundColor = ConsoleColor.White; break;
                }
            }
        }
    }
}
