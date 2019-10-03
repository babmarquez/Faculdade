using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using CG_Biblioteca;
using OpenTK.Input;

namespace CG_N2_2
{
    /*
    Implementar as funções de Pan e Zoom. Para isso, implemente uma função de 
    callback de teclado que leia as teclas e os parâmetros necessários para a função Ortho. 
    Tais parâmetros deverão ser armazenados em uma classe Camera. 
     */

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
            GL.Vertex2(0, 0); 
            GL.Vertex2(200, 0);
            GL.Color3(Color.Green);
            GL.Vertex2(0, 0); 
            GL.Vertex2(0, 200);
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
            //Desloca pra esquerda
            if (e.Key == Key.E) {
                camera.xmin-=10;
                camera.xmax-=10;
            } else 
            //Desloca pra direita
            if (e.Key == Key.D) {
                camera.xmin+=10;
                camera.xmax+=10;
            } else
            //Desloca pra cima
            if (e.Key == Key.C) {
                camera.ymin+=10;
                camera.ymax+=10;
            } else
            //Desloca pra baixo
            if (e.Key == Key.B) {
                camera.ymin-=10;
                camera.ymax-=10;
            } else
            //Aproximar
            if (e.Key == Key.I) {
                //controle para não inverter o cara com zoom máximo
                if(camera.xmax >= 1 && camera.ymax >= 1){
                    camera.xmin += 10;
                    camera.xmax -= 10;
                    camera.ymin += 10;
                    camera.ymax -= 10;
                }
            } else 
            //Afastar
            if (e.Key == Key.O) {
                //controle para não ferrar o cara com zoom mínimo
                if(camera.xmax <= 300 && camera.ymax <= 300) {
                    camera.xmin -= 10;
                    camera.xmax += 10;
                    camera.ymin -= 10;
                    camera.ymax += 10;
                }
            }
        }
    }
}
