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

    public interface IAdministrator
    {
        void Save();
        INovelElement Retrieve();
        void Delete(); 
        void View();
        void Edit();
    }

    public class Editor : IEditor{ 
        Novel novel;

        public Editor(Novel el)
        {
            novel = el;
        }

        public void Save(){
            novel.Save();
        }

        public INovelElement Retrieve()
        {
            novel.Retrieve();
        }

        public void Delete()
        {
            novel.Delete();
        } 
    }

    public class Writer : IWriter { 
        Novel novel;

        public Writer(Novel el)
        {
            novel = el;
        }
        public void View()
        {
            novel.View();
        }
        public void Edit()
        {
            novel.Edit();
        }
    }

    public class Administrator : IAdministrator{ 
        Novel novel;

        public Administrator(Novel el)
        {
            novel = el;
        }

        public void Save()
        {
            novel.Save();
        }

        public INovelElement Retrieve()
        {
            novel.Retrieve();
        }

        public void Delete()
        {
            novel.Delete();
        } 

        public void View()
        {
            novel.View();
        }

        public void Edit()
        {
            novel.Edit();
        }
    }

    public interface INovel
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
        
         public void Save()
        {
            throw new NotImplementedException();
        }

        public INovelElement Retrieve()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        } 

        public void View()
        {
            throw new NotImplementedException();
        }

        public void Edit()
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
        
         public void Save()
        {
            throw new NotImplementedException();
        }

        public INovelElement Retrieve()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        } 

        public void View()
        {
            throw new NotImplementedException();
        }

        public void Edit()
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

        public void Save()
        {
            Console.WriteLine("Saving " + _title + "...");
            Console.WriteLine(_title + " Saved!");
        }

        public abstract INovelElement Retrieve()
        {
            Console.WriteLine("Retrievin " + _title + "...");
            return null;
        }


        public abstract void Delete(); 
        // {
        //     Console.WriteLine("Deleting " + _title + "...");
        //     
        //     var itemToDelete = _elements.Find(i => i.GetTitle() == _title);
        //     
        //     if (itemToDelete != null)
        //     {
        //         _elements.Remove(itemToDelete);
        //     }
        //
        //     Console.WriteLine(_title + " Deleted");
        // }

        public void View()
        {
            
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
            //     element.View();
            //
            //     return;
            // }
        }

        public void Edit()
        {
            Console.WriteLine("Editing " + _title + "...");
        }
    }

    public interface IColumnElement {}

    public interface IFrameElement {}


    public class Frame : CompositePageElement, IColumnElement
    {
        private List<IFrameElement> _elements = new List<IFrameElement>();
        
        public override INovelElement Retrieve()
        {
            throw new NotImplementedException();
        }

        public override void Delete()
        {
            throw new NotImplementedException();
        }
    }

    public class Column : CompositePageElement, IFrameElement
    {
        
        private List<IColumnElement> _elements = new List<IColumnElement>();
        
        public override INovelElement Retrieve()
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
        public void Save()
        {
            throw new NotImplementedException();
        }

        public INovelElement Retrieve()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        } 

        public void View()
        {
            throw new NotImplementedException();
        }

        public void Edit()
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
    }
    
    internal class Program
    {
        public static void Main(string[] args)
        {
            Novel novel = new Novel("Oreo and Julieta");
            CompositePageElement page = new Page();
            CompositePageElement column = new Column();
            CompositePageElement frame = new Frame();
            CompositePageElement lineOfText = new LineOfText();
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
            CompositePageElement frameLineOfText = new LineOfText();
            frame.Add(frameColumn);
            frameColumn.Add(frameLineOfText);
            frameLineOfText.Add(new Character('4'));
            frameLineOfText.Add(new Character('2'));
            frameLineOfText.Add(new Character('1'));
            
            Writer James = new Writer();
            James.View();
        }
    }
}