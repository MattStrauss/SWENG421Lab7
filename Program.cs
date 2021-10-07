using System;
using System.Collections.Generic;

namespace Lab7
{
    public interface IEditor
    {
        void Save();
        INovelElement Retrieve();
        void Delete(); 
    }

    public interface IWriter
    {
        void View();
        void Edit();
    }

    public class Editor { 
        private IEditor _novel;

        public Editor(IEditor el)
        {
            _novel = el;
        }

        public IEditor GetNovel()
        {
            return _novel; 
        }
    }

    public class Writer { 
        private IWriter _novel;

        public Writer(IWriter el)
        {
            _novel = el;
        }
        
        public IWriter GetNovel()
        {
            return _novel; 
        }
    }

    public class Administrator { 
        private INovel _novel;

        public Administrator(INovel el)
        {
            _novel = el;
        }
        
        public INovel GetNovel()
        {
            return _novel; 
        }
    }

    public interface INovel : IWriter, IEditor
    {
        string GetTitle(); 
        
        void Add(Object element);
    }
    
    
    public interface INovelElement : INovel
    {
    }


    public class Novel : INovel
    {
        private List<INovelElement> _elements = new List<INovelElement>();
        private string _title;

        public Novel(string novelTitle)
        {
            _title = novelTitle;
        }
        
        public string GetTitle()
        {
            return _title;
        }

        public void Add(object element)
        {
            return; 
        }

        public void Add(INovelElement element)
        {
            _elements.Add(element);
        }

        public void Save()
        {
            Console.WriteLine("Saving " + _title + "...");
            Console.WriteLine(_title + " Saved!");
        }

        public INovelElement Retrieve()
        {
            Console.WriteLine("Retrieving " + _title + "...");
            return null;
        }

        public void Delete()
        {
             Console.WriteLine("Deleting " + _title + "...");
             Console.WriteLine(_title + " Deleted");
        }

        public void View()
        {
            foreach (INovelElement element in _elements)
            {
                if (element is Character)
                {
                    Character el = (Character) element; 
                    Console.Write(el.GetContent());
                }
                element.View();
            }
        }

        public void Edit()
        {
            Console.WriteLine("Editing " + _title + "...");
        }

    }
    
    public interface IPageElement : INovelElement{}
    
    
    public class Page : INovelElement
    {
        private List<IPageElement> _elements = new List<IPageElement>();

        private string _title; 

        public string GetTitle()
        {
            return _title;
        }

        public void Add(Object element)
        {
            _elements.Add((IPageElement)element);
        }

        public void Save()
        {
            Console.WriteLine("Saving Page..." );
            Console.WriteLine("Page Saved!");
        }

        public INovelElement Retrieve()
        {
            Console.WriteLine("Retrieving Page...");
            return null;
        }

        public void Delete()
        {
             Console.WriteLine("Deleting Page...");
             Console.WriteLine("Page Deleted");
        }

        public void View()
        {
            foreach (INovelElement element in _elements)
            {
                if (element is Character)
                {
                    Character el = (Character) element; 
                    Console.Write(el.GetContent());
                }
                element.View();
            }
        }

        public void Edit()
        {
            Console.WriteLine("Editing Page...");
        }
    }

    public abstract class CompositePageElement : IPageElement 
    {
        private string _title; 

        public string GetTitle()
        {
            return _title;
        }

        public abstract void Add(Object element);
        public abstract void Save();
        public abstract INovelElement Retrieve();
        public abstract void Delete();
        public abstract void View();
        public abstract void Edit();  
    }

    public interface IColumnElement {}

    public interface IFrameElement {}


    public class Frame : CompositePageElement, IColumnElement
    {
        private List<IFrameElement> _elements = new List<IFrameElement>();
        
        public override void Add(Object element)
        {
            _elements.Add((IFrameElement)element);
        }

        public override void Save()
        {
            Console.WriteLine("Saving Frame..." );
            Console.WriteLine("Frame Saved!");
        }

        public override INovelElement Retrieve()
        {
            Console.WriteLine("Retrieving Frame...");
            return null;
        }

        public override void Delete()
        {
             Console.WriteLine("Deleting Frame...");
             Console.WriteLine("Frame Deleted");
        }

        public override void View()
        {
            foreach (INovelElement element in _elements)
            {
                if (element is Character)
                {
                    Character el = (Character) element; 
                    Console.Write(el.GetContent());
                }
                element.View();
            }
        }

        public override void Edit()
        {
            Console.WriteLine("Editing Frame...");
        }
    }

    public class Column : CompositePageElement, IFrameElement
    {
        
        private List<IColumnElement> _elements = new List<IColumnElement>();
        
        public override void Add(Object element)
        {
            _elements.Add((IColumnElement)element);
        }

        public override void Save()
        {
            Console.WriteLine("Saving Column..." );
            Console.WriteLine("Column Saved!");
        }

        public override INovelElement Retrieve()
        {
            Console.WriteLine("Retrieving Column...");
            return null;
        }

        public override void Delete()
        {
             Console.WriteLine("Deleting Column...");
             Console.WriteLine("Column Deleted");
        }

        public override void View()
        {
            foreach (INovelElement element in _elements)
            {
                if (element is Character)
                {
                    Character el = (Character) element; 
                    Console.Write(el.GetContent());
                }
                element.View();
            }
        }

        public override void Edit()
        {
            Console.WriteLine("Editing Column...");
        }
    }
    
    public abstract class ColumnFrameElement : IPageElement
    { 
        private string _title; 

        public string GetTitle()
        {
            return _title;
        }
        
        public abstract void Add(Object element);
        public abstract void Save();
        public abstract INovelElement Retrieve();
        public abstract void Delete();
        public abstract void View();
        public abstract void Edit();
    }

    public class LineOfText : ColumnFrameElement, IColumnElement
    {
        private List<ILineOfTextElement> _elements = new List<ILineOfTextElement>(); 

        public override void Add(Object element)
        {
            _elements.Add((ILineOfTextElement)element);
        }

        public override void Save()
        {
            Console.WriteLine("Saving LineOfText..." );
            Console.WriteLine("LineOfText Saved!");
        }

        public override INovelElement Retrieve()
        {
            Console.WriteLine("Retrieving LineOfText...");
            return null;
        }

        public override void Delete()
        {
             Console.WriteLine("Deleting LineOfText...");
             Console.WriteLine("LineOfText Deleted");
        }

        public override void View()
        {
            foreach (INovelElement element in _elements)
            {
                if (element is Character)
                {
                    Character el = (Character) element; 
                    Console.Write(el.GetContent());
                }
            }
        }

        public override void Edit()
        {
            Console.WriteLine("Editing LineOfText...");
        }
    }

    public class Image : ColumnFrameElement, IFrameElement, IColumnElement, ILineOfTextElement
    { 
        public override void Add(Object element)
        {
            return;
        }

        public override void Save()
        {
            Console.WriteLine("Saving Image..." );
            Console.WriteLine("Image Saved!");
        }

        public override INovelElement Retrieve()
        {
            Console.WriteLine("Retrieving Image...");
            return null;
        }

        public override void Delete()
        {
             Console.WriteLine("Deleting Image...");
             Console.WriteLine("Image Deleted");
        }

        public override void View()
        {
            Console.WriteLine("Viewing Image...");
        }

        public override void Edit()
        {
            Console.WriteLine("Editing Image...");
        }
    }

    public interface ILineOfTextElement {}

    public class Character : ColumnFrameElement, ILineOfTextElement
    {
        private char _content;

        public Character(char character)
        {
            _content = character;
        }

        public char GetContent()
        {
            return _content; 
        }

        public void SetContent(char character)
        {
            _content = character; 
        }
        public override void Add(Object element)
        {
            return;
        }

        public override void Save()
        {
            Console.WriteLine("Saving Character..." );
            Console.WriteLine("Character Saved!");
        }

        public override INovelElement Retrieve()
        {
            Console.WriteLine("Retrieving Character...");
            return null;
        }

        public override void Delete()
        {
             Console.WriteLine("Deleting Character...");
             Console.WriteLine("Character Deleted");
        }

        public override void View()
        {
            Console.WriteLine("Viewing Character...");
        }

        public override void Edit()
        {
            Console.WriteLine("Editing Character...");
        }
    }
    
    internal class Program
    {
        public static void Main(string[] args)
        {
            Novel novel = new Novel("Oreo and Julieta");
            INovelElement page = new Page();
            CompositePageElement column = new Column();
            CompositePageElement frame = new Frame();
            ColumnFrameElement lineOfText = new LineOfText();
            novel.Add(page);
            page.Add(column);
            page.Add(frame);
            column.Add(lineOfText);
            lineOfText.Add(new Character('S'));
            lineOfText.Add(new Character('W'));
            lineOfText.Add(new Character('E'));
            lineOfText.Add(new Character('N'));
            lineOfText.Add(new Character('G'));
            
            CompositePageElement frameColumn = new Column();
            ColumnFrameElement frameLineOfText = new LineOfText();
            frame.Add(frameColumn);
            frameColumn.Add(frameLineOfText);
            frameLineOfText.Add(new Character('4'));
            frameLineOfText.Add(new Character('2'));
            frameLineOfText.Add(new Character('1'));
            
            Writer James = new Writer(novel);
            James.GetNovel().View();
        }
    }
}