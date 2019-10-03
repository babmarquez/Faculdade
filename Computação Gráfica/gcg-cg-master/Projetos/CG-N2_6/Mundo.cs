using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using CG_Biblioteca;
using OpenTK.Input;
using System.Collections.Generic;

namespace CG_N2_6
{
    /*
    No caso a interação deve ser:
    – para mudar entre o ponto de controle selecionado (em cor vermelha) usar as teclas “1, 2, 3 e 4”;
    – para mover o ponto selecionado (um dos pontos de controle) usar as teclas C (cima), 
    B (baixo), E (esquerda) e D (direita);
    – as teclas do sinal de mais (+) e menos (-) podem aumentar e diminui a quantidade de 
    pontos calculados na spline;
    – ao pressionar a tecla R os pontos de controle devem voltar aos valores iniciais;
    – a spline deve ser desenha usando linhas de cor amarela;
    – o poliedro de controle deve ser desenhado usando uma linha de cor ciano.
    ATENÇÃO: não é permitido usar o comando spline do OpenGL, sendo só permitido usar 
    UMA das formas de splines “demonstradas em aula”. Ao mover um dos pontos de controle, o 
    poliedro e a spline deve se ajustar aos novos valores deste ponto.
     */

    public class Mundo : GameWindow
    {
        public Mundo(int width, int height) : base(width, height) { }

        private Camera camera = new Camera();

        int qtdPontos = 5;
        private Ponto4D PontoSelecionado;

        enum pontos { A, B, C, D }

        pontos ponto;

        private Ponto4D A = new Ponto4D(x: -100, y: -100);
        private Ponto4D B = new Ponto4D(x: -100, y: 100);
        private Ponto4D C = new Ponto4D(x: 100, y: 100);
        private Ponto4D D = new Ponto4D(x: 100, y: -100);

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GL.ClearColor(Color.Gray);
            camera.xmin = -400;
            camera.xmax = 400;
            camera.ymin = -400;
            camera.ymax = 400;
            camera.zmin = 0;
            camera.zmax = 600;
            SetaValoresIniciais();
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
            criarComponentes();

            GL.LineWidth(3);
            GL.Color3(Color.Yellow);
            GL.Begin(PrimitiveType.LineStrip);

            for (double t = 0; t <= 1; t += (1D / (double)qtdPontos)){
                var ab = gerarPonto(A, B, t);
                var bc = gerarPonto(B, C, t);
                var cd = gerarPonto(C, D, t);
                var abc = gerarPonto(ab, bc, t);
                var bcd = gerarPonto(bc, cd, t);
                var abcd = gerarPonto(abc, bcd, t);
                GL.Vertex2(abcd.X, abcd.Y);
            }
            GL.Vertex2(D.X, D.Y);
            GL.End();

            this.SwapBuffers();
        }

        protected override void OnKeyDown(OpenTK.Input.KeyboardKeyEventArgs e)
        {
            if (PontoSelecionado == null)
                PontoSelecionado = A;

            if (e.Key == Key.Escape)
                Exit();

            //Reinicia
            if (e.Key == Key.R)
                SetaValoresIniciais();

            //Aumenta a quantidade de ponto da Spline
            if (e.Key == Key.Plus || e.Key == Key.KeypadPlus)
                qtdPontos++;

            //Diminui a quantidade de ponto da Spline
            if (e.Key == Key.Minus || e.Key == Key.KeypadMinus){
                if (qtdPontos > 0)
                    qtdPontos--;
            }

            //Muda pontos
            if (e.Key == Key.Number1 || e.Key == Key.Keypad1){
                PontoSelecionado = A;
                ponto = pontos.A;
            }

            if (e.Key == Key.Number2 || e.Key == Key.Keypad2){
                PontoSelecionado = B;
                ponto = pontos.B;
            }

            if (e.Key == Key.Number3 || e.Key == Key.Keypad3){
                PontoSelecionado = C;
                ponto = pontos.C;
            }

            if (e.Key == Key.Number4 || e.Key == Key.Keypad4){
                PontoSelecionado = D;
                ponto = pontos.D;
            }

            //Cima
            if (e.Key == Key.C)
                PontoSelecionado.Y++;

            //Baixo
            if (e.Key == Key.B)
                PontoSelecionado.Y--;

            //Direita
            if (e.Key == Key.D)
                PontoSelecionado.X++;

            //Esquerda
            if (e.Key == Key.E)
                PontoSelecionado.X--;
        }

        private void criarComponentes()
        {
            GL.Color3(Color.Red);
            GL.LineWidth(10);
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex2(0, 0); 
            GL.Vertex2(200, 0);
            GL.Color3(Color.Green);
            GL.Vertex2(0, 0); 
            GL.Vertex2(0, 200);
            GL.End();

            GL.LineWidth(3);
            GL.Begin(PrimitiveType.Lines);
            GL.Color3(Color.LightBlue);
            GL.Vertex2(A.X, A.Y); 
            GL.Vertex2(B.X, B.Y);
            GL.Vertex2(B.X, B.Y); 
            GL.Vertex2(C.X, C.Y);
            GL.Vertex2(C.X, C.Y); 
            GL.Vertex2(D.X, D.Y);
            GL.End();

            GL.PointSize(10);
            GL.Color3(ponto == pontos.A ? Color.Red : Color.Black);
            GL.Begin(PrimitiveType.Points);
            GL.Vertex2(A.X, A.Y);
            GL.End();

            GL.PointSize(10);
            GL.Color3(ponto == pontos.B ? Color.Red : Color.Black);
            GL.Begin(PrimitiveType.Points);
            GL.Vertex2(B.X, B.Y);
            GL.End();

            GL.PointSize(10);
            GL.Color3(ponto == pontos.C ? Color.Red : Color.Black);
            GL.Begin(PrimitiveType.Points);
            GL.Vertex2(C.X, C.Y);
            GL.End();

            GL.PointSize(10);
            GL.Color3(ponto == pontos.D ? Color.Red : Color.Black);
            GL.Begin(PrimitiveType.Points);
            GL.Vertex2(D.X, D.Y);
            GL.End();
        }

        private Ponto4D gerarPonto(Ponto4D A, Ponto4D B, double t)
        {
            var xR = A.X + (B.X - A.X) * t;
            var yR = A.Y + (B.Y - A.Y) * t;
            return new Ponto4D(xR, yR);
        }

        private void SetaValoresIniciais()
        {
            qtdPontos = 5;
            ponto = pontos.A;
            A = new Ponto4D(x: -100, y: -100);
            B = new Ponto4D(x: -100, y: 100);
            C = new Ponto4D(x: 100, y: 100);
            D = new Ponto4D(x: 100, y: -100);
        }
    }
}
