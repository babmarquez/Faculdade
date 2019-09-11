using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using CG_Biblioteca;
using OpenTK.Input;

namespace CG_N2_2
{
    public class Mundo : GameWindow
    {
        public Mundo(int width, int height) : base(width, height) { }
        private Camera camera = new Camera();

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GL.ClearColor(Color.Gray);
            camera.xmin = -300;
            camera.xmax = 300;
            camera.ymin = -300;
            camera.ymax = 300;
            camera.zmin = 0;
            camera.zmax = 600;
        }
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            // GL.Ortho(-300, 300, -300, 300, 0, 600);
            GL.Ortho(camera.xmin, camera.xmax, camera.ymin, camera.ymax, camera.zmin, camera.zmax);
        }
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.Color3(Color.Red);
            GL.LineWidth(10);
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex2(0, 0); GL.Vertex2(200, 0);
            GL.Color3(Color.Green);
            GL.Vertex2(0, 0); GL.Vertex2(0, 200);
            GL.End();
            GL.PointSize(10);
            GL.Color3(Color.Yellow);
            GL.Begin(PrimitiveType.Points);
            for (int i = 0; i < 360; i+=5)
            {
                var a = Matematica.GerarPtosCirculo(i,100,0,0);
                GL.Vertex2(a.X, a.Y);
            }
            GL.End();


            this.SwapBuffers();
        }
        protected override void OnKeyDown(OpenTK.Input.KeyboardKeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                Exit();
            else
            if (e.Key == Key.E)
            {
                camera.xmin-=10;
                camera.xmax-=10;
            }
            else
            if (e.Key == Key.D)
            {
                camera.xmin+=10;
                camera.xmax+=10;
            }
            else
            if (e.Key == Key.C)
            {
                camera.ymin+=10;
                camera.ymax+=10;
            }
            else
            if (e.Key == Key.B)
            {
                camera.ymin-=10;
                camera.ymax-=10;
            }
            else
            if (e.Key == Key.I)
            {
                camera.xmin += 10;
                camera.xmax -= 10;
                camera.ymin += 10;
                camera.ymax -= 10;
            }
            else
            if (e.Key == Key.O)
            {
                camera.xmin -= 10;
                camera.xmax += 10;
                camera.ymin -= 10;
                camera.ymax += 10;
            }
        }
    }
}
