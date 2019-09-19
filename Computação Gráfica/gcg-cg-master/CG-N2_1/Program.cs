/**
@startuml
  participant "OnLoad()" as A
  participant "OnUpdateFrame()" as B
  participant "OnRenderFrame()" as C
activate A
  A -> B:  __inicializa
deactivate A
activate B
  B -> C: __desenhar
  activate C
    C --> B: __ajustes
  deactivate B
deactivate C
@enduml
*/

using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;

namespace OlaMundo
{
  class Mundo : GameWindow
  {
    public Mundo(int width, int height) : base(width, height) { }

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
      GL.ClearColor(Color.Gray);
    }
    
    protected override void OnUpdateFrame(FrameEventArgs e)
    {
      base.OnUpdateFrame(e);
      GL.MatrixMode(MatrixMode.Projection);
      GL.LoadIdentity();
      GL.Ortho(0, 600, 0, 600, -1, 1);
    }
    protected override void OnRenderFrame(FrameEventArgs e)
    {
      base.OnRenderFrame(e);
      GL.Clear(ClearBufferMask.ColorBufferBit);
      GL.MatrixMode(MatrixMode.Modelview);
      GL.LoadIdentity();
      Sru2D();
      GL.Color3(Color.Yellow);
      GL.Begin(PrimitiveType.Lines);
      GL.Vertex2(0, 0); GL.Vertex2(100, 100);
      GL.End();
      this.SwapBuffers();
    }
    private void Sru2D()
    {
      GL.LineWidth(1);
      GL.Begin(PrimitiveType.Lines);
      GL.Color3(Color.Red);
      GL.Vertex2(0, 0); GL.Vertex2(100, 0);
      GL.Color3(Color.Green);
      GL.Vertex2(0, 0); GL.Vertex2(0, 100);
      GL.End();
    }

  }
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Hello World!");
      GameWindow window = new Mundo(600, 600);
      window.Run(1.0 / 60.0);
    }
  }
}
