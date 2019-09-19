using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using CG_Biblioteca;
using OpenTK.Input;
using System.Collections.Generic;

namespace CG_N2_5
{
    public class Mundo : GameWindow
    {
        public Mundo(int width, int height) : base(width, height) { }
        private Camera camera = new Camera();
        private int fx, fy, sx, sy;

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

            fx = 0;
            fy = 0;
            sx = 50;
            sy = 50;
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

            GL.Color3(Color.Black);
            GL.LineWidth(10);
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex2(fx, fy); GL.Vertex2(sx, sy);
            GL.End();

            this.SwapBuffers();
        }
        protected override void OnKeyDown(OpenTK.Input.KeyboardKeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                Exit();
            else
            if (e.Key == Key.Q)
            {
                fx--;
                sx--;
            }
            else
            if (e.Key == Key.W)
            {
                fx++;
                sx++;
            }
            else
            if (e.Key == Key.A)
            {
                sy++;
                sx++;
            }
            else
            if (e.Key == Key.S)
            {
                sy--;
                sx--;
            }
            else
            if (e.Key == Key.Z)
            {
                var a = Matematica.GerarPtosCirculo(Matematica.angle(fx,fy,sx,sy)-1,Matematica.distance(fx,sx,fy,sy),0,0);
                sy = Convert.ToInt32(a.Y);
                sx = Convert.ToInt32(a.X);
            }
            else
            if (e.Key == Key.X)
            {
                var a = Matematica.GerarPtosCirculo(Matematica.angle(fx,fy,sx,sy)+1,Matematica.distance(fx,sx,fy,sy),0,0);
                sy = Convert.ToInt32(a.Y);
                sx = Convert.ToInt32(a.X);
            }
        }
    }
}
