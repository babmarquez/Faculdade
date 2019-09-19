using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using CG_Biblioteca;

namespace CG_N2_7
{
    public class Mundo : GameWindow
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
            GL.Ortho(-300, 300, -300, 300, 0, 600);
        }
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.Color3(Color.Green);
            GL.LineWidth(10);
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex2(-250, 0); GL.Vertex2(-250, -300);
            GL.Color3(Color.Brown);
            GL.Vertex2(0, -250); GL.Vertex2(-300, -250);
            GL.End();
            Ponto4D pto = new Ponto4D(0,0,0,1);
            var bb = new BBox();
            bb.Atribuir(pto);
            bb.Desenhar();

            this.SwapBuffers();
        }
    }
}
