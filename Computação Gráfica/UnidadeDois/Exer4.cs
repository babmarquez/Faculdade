using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using CG_Biblioteca;
using OpenTK.Input;
using System.Collections.Generic;

namespace UnidadeDois
{
    public class Exer4 : GameWindow
    {
        public Exer4(int width, int height) : base(width, height) { }
        private Camera camera = new Camera();
        private List<PrimitiveType> lprimi = new List<PrimitiveType>{
            PrimitiveType.Points, 
            PrimitiveType.Lines,
            PrimitiveType.LineLoop,
            PrimitiveType.LineStrip,
            PrimitiveType.Triangles,
            PrimitiveType.TriangleStrip,
            PrimitiveType.TriangleFan,
            PrimitiveType.Quads,
            PrimitiveType.QuadStrip,
            PrimitiveType.Polygon,
        };
        private int primitiva = 0;

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
            GL.Color3(0,0.99,0.99);

            GL.Begin(lprimi[primitiva]);
            GL.Vertex2(-200, 200);
            GL.Color3(0.9,0.4,0.98);
            GL.Vertex2(200, 200);
            GL.Color3(Color.Yellow);
            GL.Vertex2(-200, -200);
            GL.Color3(Color.Black);
            GL.Vertex2(200, -200);
            GL.End();
            
            this.SwapBuffers();
        }
        protected override void OnKeyDown(OpenTK.Input.KeyboardKeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                Exit();
            else
            if (e.Key == Key.Space)
            {
                if (primitiva < lprimi.Count-1)
                    primitiva++;
                else
                    primitiva=0;
            }
        }
    }
}
