using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jogo_da_Velha_csharp
{
    public partial class Form1 : Form
    {
        //variávies globais:
        int Xplayer = 0, Oplayer = 0, empatesPontos = 0, rodadas = 0;

        bool turno = true, jogo_final = false;

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        string[] texto = new string[9]; //array que armazenará o conteúdo dos botões




        private void btnReset_Click(object sender, EventArgs e)
        {
            // Botão passa a ser uma variável item, e passamos o nome do painel onde os botões estão 
            foreach (Control item in panel1.Controls)
            {
                if (item is Button btn){
                    btn.Text = ""; // zera o conteúdo de todos os botões

                }
            }
            rodadas = 0; //zerando as rodadas
            jogo_final = false; //jogo_final = false, quer dizer que o jogo acabou
            texto = new string[9]; //como é uma nova string, os dados nulos serão passados
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            //método no qual quando qualquer botão é clicado, ele executa os seguintes comandos abaixo:
            Button btn = (Button)sender;

            int buttonIndex = btn.TabIndex;


            //verificando se o botão está vazio, e se sim, ele entra no outro if
            if (btn.Text == "" && jogo_final == false)
            {

                //se o turno for true, será a vez do X, caso contrário, será a vez da bolinha       
                if (turno == true)
                {
                    btn.Text = "X";
                    texto[buttonIndex] = btn.Text; //passando o parâmetro buttonIndex ao clicar no botão 
                    rodadas++; //incremento nas rodadas
                    turno = !turno; // turno é igual ao seu inverso, ou seja, se for true, passará a ser false
                    lblturnos.Text = turno ? "vez de X" : "Vez de O";
                    Checagem(1);
                }
                //caso contrário será a vez do Bolinha
                else
                {
                    btn.Text = "O";
                    texto[buttonIndex] = btn.Text;  //passando o parâmetro buttonIndex ao clicar no botão 
                    rodadas++;   //incremento nas rodadas
                    turno = !turno; // turno é igual ao seu inverso, ou seja, se for false, passará a ser true
                    lblturnos.Text = turno ? "vez de X" : "Vez de O";
                    Checagem(2);

                }//fim da estrutura

            } //final método do botão


            //método do jogador vencedor
            void vencedor(int PlayerQueGanhou)
            {
                //quando o método for chmamado, o jogo já terá acabado
                jogo_final = true;

                //se o vencedor for o jogador 1
                if (PlayerQueGanhou == 1)
                {
                    Xplayer++;  //incremento nos pontos do jogador X
                    pontosX.Text = Convert.ToString(Xplayer);  //mostrando os pontos na tela
                    MessageBox.Show("Jogador X Ganhou!");
                    turno = true; //o jogador X começará na próxima rodada
                }
                else
                {
                    Oplayer++;  //incremento nos pontos do jogador X
                    pontosO.Text = Convert.ToString(Oplayer); //mostrando os pontos na tela
                    MessageBox.Show("Jogador O Ganhou!");
                    turno = false; //o jogador O começará na próxima rodada
                }

            }


            //método de checagem de valores do array
            void Checagem(int ChecagemPlayer)
            {
                //variável suporte fundamental na checagem
                string suporte = "";

                if (ChecagemPlayer == 1)
                {
                    suporte = "X";
                }
                else
                {
                    suporte = "O";
                }//fim do suporte

                //**************************************************** CHECAGEM HORIZONTAL **********************************************************

                //loop usado para verificação na horizontal, sendo executado 8 vezes, incrementando de 3 em 3 verificando as horizontais da matriz
                for (int horizontal = 0; horizontal < 8; horizontal += 3)
                {

                    //se o suporte for igual ao conteúdo dentro do array ele entra na condição abaixo:
                    if (suporte == texto[horizontal])
                    {
                        //checagem Horizontal:
                        //verificando se o conteúdo dentro do array são iguais
                        // +1 verifica o botão do meio | +2 verifica o conteúdo do terceiro botão da horizontal
                        if (texto[horizontal] == texto[horizontal + 1] && texto[horizontal] == texto[horizontal + 2])
                        {
                            vencedor(ChecagemPlayer);
                            return;

                        } //final da checagem na horizontal
                    }
                }//fim do loop



                //************************************************* CHECAGEM VERTICAL ******************************************************************

                //loop usado para verificação na horizontal, sendo executado 3 vezes, incrementando de 1 em 1, verifiando as verticais
                for (int vertical = 0; vertical < 3; vertical++)
                {

                    //se o suporte for igual ao conteúdo dentro do array ele entra na condição abaixo:
                    if (suporte == texto[vertical])
                    {
                        //checagem Vertical:

                        //verificando se o conteúdo dentro do array são iguais
                        // +3 verifica o valor abaixo do botão | +6 verifica o conteúdo do terceiro botão da vertical
                        if (texto[vertical] == texto[vertical + 3] && texto[vertical] == texto[vertical + 6])
                        {
                            vencedor(ChecagemPlayer);
                            return;

                        }
                    }//final da checagem na vertical
                }//fim do loop


                //****************************************************** CHECAGEM DIAGONAIS ************************************************************
                if (texto[0] == suporte)
                {

                    if (texto[0] == texto[4] && texto[0] == texto[8])
                    {
                        vencedor(ChecagemPlayer);
                        return;
                    }//diagonal principal

                   

                }

                if (texto[2] == suporte)
                {
                    if (texto[2] == texto[4] && texto[2] == texto[6])
                    {
                        vencedor(ChecagemPlayer);
                        return;
                    }// diagonal secundária
                }

                //verificação do empate
                if (rodadas == 9 && jogo_final == false)
                {
                    empatesPontos++;
                    empates.Text = Convert.ToString(empatesPontos);
                    MessageBox.Show("Empate!");
                    jogo_final = true;
                    return;
                }




            }


        }
    }
}
