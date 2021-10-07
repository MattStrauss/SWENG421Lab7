using System;
using System.Collections.Generic;

namespace Lab7
{
    public interface IEditor
    {
        void Save(string title);
        void Retrieve();
        void Delete(string title); 
    }

    public interface IWriter
    {
        void View(string title);
        void Edit(string title);
    }

    public interface INovel : IEditor, IWriter
    {
        string GetTitle(); 
    }
    
    
    public interface INovelElement : INovel {}

    public abstract class CompositeTopLevelElement
    {
        private string _title;

        string GetTitle()
        {
            return _title; 
        }
        
    }

    public class Novel : INovel
    {
        private List<INovelElement> _elements = new List<INovelElement>();
        
        public void Save(string title)
        {
            throw new NotImplementedException();
        }

        public void Retrieve()
        {
            throw new NotImplementedException();
        }

        public void Delete(string title)
        {
            throw new NotImplementedException();
        }

        public void View(string title)
        {
            throw new NotImplementedException();
        }

        public void Edit(string title)
        {
            throw new NotImplementedException();
        }

        public string GetTitle()
        {
            throw new NotImplementedException();
        }
    }
    
    public interface IPageElement : INovel {}
    
    
    public class Page : INovelElement
    {
        private List<IPageElement> _elements = new List<IPageElement>();
        
        public void Save(string title)
        {
            throw new NotImplementedException();
        }

        public void Retrieve()
        {
            throw new NotImplementedException();
        }

        public void Delete(string title)
        {
            throw new NotImplementedException();
        }

        public void View(string title)
        {
            throw new NotImplementedException();
        }

        public void Edit(string title)
        {
            throw new NotImplementedException();
        }

        public string GetTitle()
        {
            throw new NotImplementedException();
        }
    }

    public abstract class CompositePageElement : IPageElement
    {
        private string _title;

        public string GetTitle()
        {
            return _title; 
        }

        public void Save(string title)
        {
            Console.WriteLine("Saving " + title + "...");
            Console.WriteLine(title + " Saved!");
        }

        public abstract void Retrieve();


        // foreach (INovelElement element in _elements)
            // {
            //     if (element is Character)
            //     {
            //         Character el = (Character) element; 
            //         Console.Write(el.GetContent());
            //
            //         return; 
            //     }
            //     
            //     element.Retrieve();
            //
            //     return;
            // }


        public abstract void Delete(string title); 
        // {
        //     Console.WriteLine("Deleting " + title + "...");
        //     
        //     var itemToDelete = _elements.Find(i => i.GetTitle() == title);
        //     
        //     if (itemToDelete != null)
        //     {
        //         _elements.Remove(itemToDelete);
        //     }
        //
        //     Console.WriteLine(title + " Deleted");
        // }

        public void View(string title)
        {
            Console.WriteLine("Viewing " + title + "...");
        }

        public void Edit(string title)
        {
            Console.WriteLine("Editing " + title + "...");
        }
    }

    public interface IColumnElement {}

    public interface IFrameElement {}


    public class Frame : CompositePageElement, IColumnElement
    {
        private List<IFrameElement> _elements = new List<IFrameElement>();
        
        public override void Retrieve()
        {
            throw new NotImplementedException();
        }

        public override void Delete(string title)
        {
            throw new NotImplementedException();
        }
    }

    public class Column : CompositePageElement, IFrameElement
    {
        
        private List<IColumnElement> _elements = new List<IColumnElement>();
        
        public override void Retrieve()
        {
            throw new NotImplementedException();
        }

        public override void Delete(string title)
        {
            throw new NotImplementedException();
        }
    }
    
    public abstract class ColumnFrameElement : IPageElement
    {
        public void Save(string title)
        {
            throw new NotImplementedException();
        }

        public void Retrieve()
        {
            throw new NotImplementedException();
        }

        public void Delete(string title)
        {
            throw new NotImplementedException();
        }

        public void View(string title)
        {
            throw new NotImplementedException();
        }

        public void Edit(string title)
        {
            throw new NotImplementedException();
        }

        public string GetTitle()
        {
            throw new NotImplementedException();
        }
    }

    public class LineOfText : ColumnFrameElement, IColumnElement, ILineOfTextElement
    {
        private List<ILineOfTextElement> _elements = new List<ILineOfTextElement>(); 
    }

    public class Image : ColumnFrameElement, IFrameElement, IColumnElement, ILineOfTextElement
    {
        
    }

    public interface ILineOfTextElement {}

    public class Character : ColumnFrameElement, ILineOfTextElement
    {
        private char _content;

        public char GetContent()
        {
            return _content; 
        }

        public void SetContent(char character)
        {
            _content = character; 
        }
    }
    
    internal class Program
    {
        public static void Main(string[] args)
        {
        }
    }
}