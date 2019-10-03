using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using CG_Biblioteca;

namespace CG_N2_1
{
    /*
    - desenhe somente os eixos positivos x e y, cada um com comprimento igual a 200;
    - experimente mudar a cor de fundo da tela para cinza e a cor de desenho dos pontos para amarelo;
    - utilize as funções sin(ang) e cos(ang) da Classe Matematica fornecida;
    - não é permitido usar o comando circle do OpenGL e nem outra implementação que não use as funções da classe Matematica.
     */

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
            
            GL.Color3(Color.Red);
            GL.LineWidth(10); //grossura da linha
            GL.Begin(PrimitiveType.Lines);
            //Eixo X e Y
            GL.Vertex2(0, 0); 
            GL.Vertex2(200, 0);
            GL.Color3(Color.Green);
            //Eixo X e Y
            GL.Vertex2(0, 0); 
            GL.Vertex2(0, 200);
            GL.End();
            //Círculo
            GL.PointSize(10);
            GL.Color3(Color.Yellow);
            GL.Begin(PrimitiveType.Points);
            //Cria circulo(incrementa em 5 para não perder a linha)            
            for (int i = 0; i < 360; i+=5)
            {
                var a = Matematica.GerarPtosCirculo(i,100,0,0);
                GL.Vertex2(a.X, a.Y);
            }
            GL.End(); //finaliza a criação do círculo

            this.SwapBuffers();
        }
    }
}
