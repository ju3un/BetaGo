﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Omok
{
    public partial class Form1 : Form
    {
        enum 돌종류 { 없음, 흑돌, 백돌 };
        private int 시작위치 = 30;
        private int 눈금크기 = 30;
        private int 돌크기 = 20;
        private int 화점크기 = 10;
        private int 바둑판크기 = 19;
        private Stack<Point> st = new Stack<Point>();


        private int 전x좌표 = -1, 전y좌표 = -1;
        private int 전돌x좌표 = -1, 전돌y좌표 = -1;
        private int 현재돌x좌표 = -1, 현재돌y좌표 = -1;
        private Pen 검은펜 = new Pen(Color.Black);
        private SolidBrush 빨간색 = new SolidBrush(Color.Red);
        private SolidBrush 검은색 = new SolidBrush(Color.Black);
        private SolidBrush 흰색 = new SolidBrush(Color.White);

        private int[,] 바둑판 = new int[19, 19];
        private bool 흑돌차례 = true;
        private bool 게임종료 = false;
        private bool 삼삼 = false;
        private bool AI모드 = true;
        private 돌종류 컴퓨터돌;

        private SoundPlayer 시작효과음 = new SoundPlayer(Properties.Resources.대국시작);
        private SoundPlayer 종료효과음 = new SoundPlayer(Properties.Resources.대국종료);
        private SoundPlayer 승리효과음 = new SoundPlayer(Properties.Resources.대국승리);
        private SoundPlayer 바둑돌소리 = new SoundPlayer(Properties.Resources.바둑돌소리);
        private SoundPlayer 무르기요청 = new SoundPlayer(Properties.Resources.무르기);
        private SoundPlayer 오류효과음 = new SoundPlayer(Properties.Resources.오류);


        private AI ai;


        public Form1()
        {
            InitializeComponent();

            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;

            시작효과음.Play();

            ai = new AI(바둑판);
            컴퓨터돌 = 돌종류.백돌;
        }

        private void 시작ToolStripMenuItem_Click(object sender, EventArgs e)  // 재시작 메뉴 (변수 전부 초기화 하고 화면 클리어)
        {
            Array.Clear(바둑판, 0, 바둑판크기 * 바둑판크기);
            전x좌표 = 전y좌표 = -1;
            전돌x좌표 = 전돌y좌표 = -1;
            현재돌x좌표 = 현재돌y좌표 = -1;
            흑돌차례 = true;
            삼삼 = false;
            게임종료 = false;
            시작효과음.Play();

            st.Clear();

            if (AI모드 == true && 컴퓨터돌 == 돌종류.흑돌)
                컴퓨터두기();

            panel1.Invalidate();
        }
        private void 한수무르기()
        {
            st.Pop();
            바둑판[현재돌x좌표, 현재돌y좌표] = (int)돌종류.없음;
           
            if (st.Count != 0)
            {
                현재돌x좌표 = st.Peek().X;
                현재돌y좌표 = st.Peek().Y;
            }
            else
            {
                현재돌x좌표 = 현재돌y좌표 = -1;
            }
        }
        
        private void 무르기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!게임종료 && st.Count != 0)
            {
                무르기요청.Play();

                if (MessageBox.Show("한 수 무르시겠습니까?", "무르기", MessageBoxButtons.YesNo) == DialogResult.Yes) // MessageBox 띄워서 무르기 여부 확인하고 예를 누르면
                {
                    if(AI모드)
                    {
                        한수무르기();
                        한수무르기();
                    }

                    else
                    {
                        한수무르기();
                        흑돌차례 = !흑돌차례;
                    }


                    panel1.Invalidate();
                }
            }
        }

        private void 종료ToolStripMenuItem_Click(object sender, EventArgs e)  // 프로그램 종료
        {
            종료효과음.PlaySync();
            
            Application.Exit();
            Environment.Exit(0);
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void com흑돌ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AI모드 == false || 컴퓨터돌 == 돌종류.백돌)
            {
                컴퓨터돌 = 돌종류.흑돌;
                com백돌ToolStripMenuItem.Checked = false;
                com흑돌ToolStripMenuItem.Checked = true;
                AI모드 = true;
                시작ToolStripMenuItem_Click(sender, e);
            }            
        }

        private void com백돌ToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            if (AI모드 == false || 컴퓨터돌 == 돌종류.흑돌)
            {
                컴퓨터돌 = 돌종류.백돌;
                com백돌ToolStripMenuItem.Checked = true;
                com흑돌ToolStripMenuItem.Checked = false;
                AI모드 = true;
                시작ToolStripMenuItem_Click(sender, e);
            }
        }

        private void 인vsPlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AI모드 == true)
            {
                AI모드 = false;
                시작ToolStripMenuItem_Click(sender, e);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < 바둑판크기; i++)                     // 바둑판 선 그리기
            {
                e.Graphics.DrawLine(검은펜, 시작위치, 시작위치 + i * 눈금크기, 시작위치 + 18 * 눈금크기, 시작위치 + i * 눈금크기);
                e.Graphics.DrawLine(검은펜, 시작위치 + i * 눈금크기, 시작위치, 시작위치 + i * 눈금크기, 시작위치 + 18 * 눈금크기);
            }

            for (int i = 0; i < 3; i++)                              // 화점 그리기
            {
                for (int j = 0; j < 3; j++)
                {
                    Rectangle r = new Rectangle(시작위치 + 눈금크기 * 3 + 눈금크기 * i * 6 - 화점크기 / 2,
                        시작위치 + 눈금크기 * 3 + 눈금크기 * j * 6 - 화점크기 / 2, 화점크기, 화점크기);

                    e.Graphics.FillEllipse(검은색, r);
                }
            }

            for (int i = 0; i < 바둑판크기; i++)
                for (int j = 0; j < 바둑판크기; j++)
                    돌그리기(i, j);

            if (현재돌x좌표 >= 0 && 현재돌y좌표 >= 0)
                현재돌표시();

            다음돌표시();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            int x, y;

            if (e.Button != MouseButtons.Left)                             // 왼쪽클릭만 허용
                return;

            x = (e.X - 시작위치 + 10) / 눈금크기;
            y = (e.Y - 시작위치 + 10) / 눈금크기;

            if (x < 0 || x >= 바둑판크기 || y < 0 || y >= 바둑판크기)      // 바둑판 크기를 벗어나는지 확인
                return;

            else if (바둑판[x, y] == (int)돌종류.없음 && !게임종료)             // 바둑판 해당 좌표에 아무것도 없고, 게임이 끝나지 않았으면
            {
                
                돌두기(x, y);
                돌그리기(x, y);
                현재돌표시();
                오목확인(x, y);

                if (!삼삼)
                {
                    st.Push(new Point(x, y));

                    if (AI모드)
                    {
                        컴퓨터두기();
                    }

                    else
                    {
                        Rectangle r = new Rectangle(시작위치, 590, 시작위치 + 돌크기 + 160, 돌크기 + 10);
                        panel1.Invalidate(r);
                    }
                }   
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)     // 현재 차례의 돌 잔상 구현 (마우스 움직일때)
        {
            int x, y;

            Color 검은색투명화 = Color.FromArgb(70, Color.Black);
            Color 흰색투명화 = Color.FromArgb(70, Color.White);
            SolidBrush 투명한검은색 = new SolidBrush(검은색투명화);
            SolidBrush 투명한흰색 = new SolidBrush(흰색투명화);

            x = (e.X - 시작위치 + 10) / 눈금크기;
            y = (e.Y - 시작위치 + 10) / 눈금크기;

            if (x < 0 || x >= 바둑판크기 || y < 0 || y >= 바둑판크기)      // 바둑판 크기를 벗어나는지 확인
                return;

            else if (바둑판[x, y] == (int)돌종류.없음 && !게임종료 && (전x좌표 != x || 전y좌표 != y))             // 바둑판 해당 좌표에 아무것도 없고, 좌표가 변경되면
            {
                Graphics g = panel1.CreateGraphics();

                Rectangle 앞에찍은돌을지우기위한구역 = new Rectangle(시작위치 + 눈금크기 * 전x좌표 - 돌크기 / 2,
                    시작위치 + 눈금크기 * 전y좌표 - 돌크기 / 2, 돌크기, 돌크기);

                Rectangle r = new Rectangle(시작위치 + 눈금크기 * x - 돌크기 / 2,
                    시작위치 + 눈금크기 * y - 돌크기 / 2, 돌크기, 돌크기);

                panel1.Invalidate(앞에찍은돌을지우기위한구역);               // 먼저 그린 잔상을 지우고 새로운 잔상을 그린다.

                if (흑돌차례)
                    g.FillEllipse(투명한검은색, r);
                else
                    g.FillEllipse(투명한흰색, r);

                전x좌표 = x;
                전y좌표 = y;
            }
        }

        private void 돌두기(int x, int y)
        {
            if (흑돌차례)                           // 검은 돌
                바둑판[x, y] = (int)돌종류.흑돌;

            else                                    // 흰 돌
                바둑판[x, y] = (int)돌종류.백돌;

            if (삼삼확인(x, y) && 흑돌차례)
            {
                오류효과음.Play();
                MessageBox.Show("금수자리입니다. \r다른곳에 놓아주세요.", "금수 - 쌍삼");
                바둑판[x, y] = (int)돌종류.없음;
                삼삼 = true;

                return;
            }

            else
            {
                전돌x좌표 = 현재돌x좌표;
                전돌y좌표 = 현재돌y좌표;

                현재돌x좌표 = x;
                현재돌y좌표 = y;

                삼삼 = false;
                흑돌차례 = !흑돌차례;                   // 차례 변경

                
                바둑돌소리.Play();
            }            
        }

        private void 돌그리기(int x, int y)
        {
            Graphics g = panel1.CreateGraphics();

            Rectangle r = new Rectangle(시작위치 + 눈금크기 * x - 돌크기 / 2,
                시작위치 + 눈금크기 * y - 돌크기 / 2, 돌크기, 돌크기);

            if (바둑판[x, y] == (int)돌종류.흑돌)                              // 검은 돌
                g.FillEllipse(검은색, r);

            else if (바둑판[x, y] == (int)돌종류.백돌)                         // 흰 돌
                g.FillEllipse(흰색, r);
        }

        private void 다음돌표시()        // 화면 하단에 다음에 둘 돌의 색을 표시
        {
            Graphics g = panel1.CreateGraphics();
            string str;
            Font 글꼴 = new Font("HY견고딕", 15);

            if (흑돌차례)        // 다음 돌 표시(검은 돌)
            {
                str = "다음 돌 : 검은 돌";
                g.FillEllipse(검은색, 시작위치 + 170, 599, 돌크기, 돌크기);
                g.DrawString(str, 글꼴, 검은색, 시작위치, 600);
            }

            else                 // 다음 돌 표시(흰 돌)
            {
                str = "다음 돌 : 흰 돌";
                g.FillEllipse(흰색, 시작위치 + 150, 599, 돌크기, 돌크기);
                g.DrawString(str, 글꼴, 검은색, 시작위치, 600);
            }

        }

        private void 현재돌표시()        // 가장 최근에 놓은 돌에 화점 크기만한 빨간 점으로 표시하기
        {
            Graphics g = panel1.CreateGraphics();

            Rectangle 앞에찍은돌을다시찍기위한구역 = new Rectangle(시작위치 + 눈금크기 * 전돌x좌표 - 돌크기 / 2,
                시작위치 + 눈금크기 * 전돌y좌표 - 돌크기 / 2, 돌크기, 돌크기);

            Rectangle r = new Rectangle(시작위치 + 눈금크기 * 현재돌x좌표 - 화점크기 / 2,
                    시작위치 + 눈금크기 * 현재돌y좌표 - 화점크기 / 2, 화점크기, 화점크기);

            if (전돌x좌표 >= 0 && 전돌y좌표 >= 0)       // 초기화값이 -1이므로 -1보다 큰 값이 존재하면 찍은 값이 존재함
            {

                if (바둑판[전돌x좌표, 전돌y좌표] == (int)돌종류.흑돌)                // 전돌 다시 찍어서 빨간 점 없애기
                    g.FillEllipse(검은색, 앞에찍은돌을다시찍기위한구역);

                else if (바둑판[전돌x좌표, 전돌y좌표] == (int)돌종류.백돌)
                    g.FillEllipse(흰색, 앞에찍은돌을다시찍기위한구역);
            }

            g.FillEllipse(빨간색, r);      // 화점 크기만큼 빨간 점 찍기
        }

        private void 오목확인(int x, int y)
        {
            if (가로확인(x, y) == 5)        // 같은 돌 개수가 5개면 (6목이상이면 게임 계속) 
            {
                승리효과음.Play();
                MessageBox.Show((돌종류)바둑판[x, y] + " 승");
                게임종료 = true;
            }

            else if (세로확인(x, y) == 5)
            {
                승리효과음.Play();
                MessageBox.Show((돌종류)바둑판[x, y] + " 승");
                게임종료 = true;
            }

            else if (사선확인(x, y) == 5)
            {
                승리효과음.Play();
                MessageBox.Show((돌종류)바둑판[x, y] + " 승");
                게임종료 = true;
            }

            else if (역사선확인(x, y) == 5)
            {
                승리효과음.Play();
                MessageBox.Show((돌종류)바둑판[x, y] + " 승");
                게임종료 = true;
            }
        }

        private int 가로확인(int x, int y)      // ㅡ 확인
        {
            int 같은돌개수 = 1;

            for (int i = 1; i <= 5; i++)
            {
                if (x + i <= 18 && 바둑판[x + i, y] == 바둑판[x, y])
                    같은돌개수++;

                else
                    break;
            }

            for (int i = 1; i <= 5; i++)
            {
                if (x - i >= 0 && 바둑판[x - i, y] == 바둑판[x, y])
                    같은돌개수++;

                else
                    break;
            }

            return 같은돌개수;
        }

        private int 세로확인(int x, int y)      // | 확인
        {
            int 같은돌개수 = 1;

            for (int i = 1; i <= 5; i++)
            {
                if (y + i <= 18 && 바둑판[x, y + i] == 바둑판[x, y])
                    같은돌개수++;

                else
                    break;
            }

            for (int i = 1; i <= 5; i++)
            {
                if (y - i >= 0 && 바둑판[x, y - i] == 바둑판[x, y])
                    같은돌개수++;

                else
                    break;
            }

            return 같은돌개수;
        }

        private int 사선확인(int x, int y)      // / 확인
        {
            int 같은돌개수 = 1;

            for (int i = 1; i <= 5; i++)
            {
                if (x + i <= 18 && y - i >= 0 && 바둑판[x + i, y - i] == 바둑판[x, y])
                    같은돌개수++;

                else
                    break;
            }

            for (int i = 1; i <= 5; i++)
            {
                if (x - i >= 0 && y + i <= 18 && 바둑판[x - i, y + i] == 바둑판[x, y])
                    같은돌개수++;

                else
                    break;
            }

            return 같은돌개수;
        }

        private int 역사선확인(int x, int y)     // ＼ 확인
        {
            int 같은돌개수 = 1;

            for (int i = 1; i <= 5; i++)
            {
                if (x + i <= 18 && y + i <= 18 && 바둑판[x + i, y + i] == 바둑판[x, y])
                    같은돌개수++;

                else
                    break;
            }

            for (int i = 1; i <= 5; i++)
            {
                if (x - i >= 0 && y - i >= 0 && 바둑판[x - i, y - i] == 바둑판[x, y])
                    같은돌개수++;

                else
                    break;
            }

            return 같은돌개수;
        }

        private bool 삼삼확인(int x, int y)     // 33확인
        {
            int 삼삼확인 = 0;

            삼삼확인 += 가로삼삼확인(x, y);
            삼삼확인 += 세로삼삼확인(x, y);
            삼삼확인 += 사선삼삼확인(x, y);
            삼삼확인 += 역사선삼삼확인(x, y);

            if (삼삼확인 >= 2)
                return true;

            else
                return false;
        }

        private int 가로삼삼확인(int x, int y)    // 가로 (ㅡ) 확인
        {
            int 돌3개확인 = 1;
            int i, j;
            
            for (i = 1; i <= 3; i++) // 돌을 둔 위치로부터 → 확인
            {
                if (x + i > 18)
                    break;

                else if (바둑판[x + i, y] == 바둑판[x, y])
                    돌3개확인++;

                else if (바둑판[x + i, y] != (int)돌종류.없음)
                    break;
            }

            for (j = 1; j <= 3; j++) // 돌을 둔 위치로부터 ← 확인
            {
                if (x - j < 0)
                    break;

                else if (바둑판[x - j, y] == 바둑판[x, y])
                    돌3개확인++;

                else if (바둑판[x - j, y] != (int)돌종류.없음)
                    break;
            }

            if (돌3개확인 == 3 && x + i < 18 && x - j > 0)    //돌 개수가 3개면서 양쪽 벽에 붙어잇으면 안된다
            {
                if ((바둑판[x + i, y] != (int)돌종류.없음 && 바둑판[x + i - 1, y] != (int)돌종류.없음) || (바둑판[x - j, y] != (int)돌종류.없음 && 바둑판[x - j + 1, y] != (int)돌종류.없음))
                {
                    return 0;
                }

                else
                    return 1;
            }

            return 0;
        }

        private int 세로삼삼확인(int x, int y)    // 세로 (|) 확인
        {
            int 돌3개확인 = 1;
            int i, j;

            돌3개확인 = 1;

            for (i = 1; i <= 3; i++) // 돌을 둔 위치로부터 ↓ 확인
            {
                if (y + i > 18)
                    break;

                else if (바둑판[x, y + i] == 바둑판[x, y])
                    돌3개확인++;

                else if (바둑판[x, y + i] != (int)돌종류.없음)
                    break;
            }

            for (j = 1; j <= 3; j++) // 돌을 둔 위치로부터 ↑ 확인
            {
                if (y - j < 0)
                    break;

                else if (바둑판[x, y - j] == 바둑판[x, y])
                    돌3개확인++;

                else if (바둑판[x, y - j] != (int)돌종류.없음)
                    break;
            }

            if (돌3개확인 == 3 && y + i < 18 && y - j > 0)    //돌 개수가 3개면서 양쪽 벽에 붙어잇으면 안된다
            {
                if ((바둑판[x, y + i] != (int)돌종류.없음 && 바둑판[x, y + i - 1] != (int)돌종류.없음) || (바둑판[x, y - j] != (int)돌종류.없음 && 바둑판[x, y - j + 1] != (int)돌종류.없음))
                {
                    return 0;
                }

                else
                    return 1;
            }

            return 0;
        }

        private int 사선삼삼확인(int x, int y)    // 사선 (/) 확인
        {
            int 돌3개확인 = 1;
            int i, j;

            돌3개확인 = 1;

            for (i = 1; i <= 3; i++) // 돌을 둔 위치로부터 ↗ 확인
            {
                if (x + i > 18 || y - i < 0)
                    break;

                else if (바둑판[x + i, y - i] == 바둑판[x, y])
                    돌3개확인++;

                else if (바둑판[x + i, y - i] != (int)돌종류.없음)
                    break;
            }

            for (j = 1; j <= 3; j++) // 돌을 둔 위치로부터 ↙ 확인
            {
                if (x - j < 0 || y + j > 18)
                    break;

                else if (바둑판[x - j, y + j] == 바둑판[x, y])
                    돌3개확인++;

                else if (바둑판[x - j, y + j] != (int)돌종류.없음)
                    break;
            }

            if (돌3개확인 == 3 && x + i < 18 && y - i > 0 && x - j > 0 && y + j < 18)    //돌 개수가 3개면서 양쪽 벽에 붙어잇으면 안된다
            {
                if ((바둑판[x + i, y - i] != (int)돌종류.없음 && 바둑판[x + i - 1, y - i + 1] != (int)돌종류.없음) || (바둑판[x - j, y + j] != (int)돌종류.없음 && 바둑판[x - j + 1, y + j - 1] != (int)돌종류.없음))
                {
                    return 0;
                }

                else
                    return 1;
            }

            return 0;
        }
        
        private int 역사선삼삼확인(int x, int y)    // 역사선 (＼) 확인
        {
            int 돌3개확인 = 1;
            int i, j;
           
            돌3개확인 = 1;

            for (i = 1; i <= 3; i++) // 돌을 둔 위치로부터 ↘ 확인
            {
                if (x + i > 18 || y + i > 18)
                    break;

                else if (바둑판[x + i, y + i] == 바둑판[x, y])
                    돌3개확인++;

                else if (바둑판[x + i, y + i] != (int)돌종류.없음)
                    break;
            }

            for (j = 1; j <= 3; j++) // 돌을 둔 위치로부터 ↖ 확인
            {
                if (x - j < 0 || y - j < 0)
                    break;

                else if (바둑판[x - j, y - j] == 바둑판[x, y])
                    돌3개확인++;

                else if (바둑판[x - j, y - j] != (int)돌종류.없음)
                    break;
            }

            if (돌3개확인 == 3 && x + i < 18 && y + i < 18 && x - j > 0 && y - j > 0)    //돌 개수가 3개면서 양쪽 벽에 붙어잇으면 안된다
            {
                if ((바둑판[x + i, y + i] != (int)돌종류.없음 && 바둑판[x + i - 1, y + i - 1] != (int)돌종류.없음) || (바둑판[x - j, y - j] != (int)돌종류.없음 && 바둑판[x - j + 1, y - j + 1] != (int)돌종류.없음))
                {
                    return 0;
                }

                else
                    return 1;
            }

            return 0;
        }
       
        void 컴퓨터두기()
        {
            int x = 0, y = 0;

            do {
                ai.AI_PutAIPlayer(ref x, ref y, false, 2);
                돌두기(x, y);
            } while (삼삼);

            돌그리기(x, y);
            현재돌표시();
            오목확인(x, y);

            st.Push(new Point(x, y));
        }
    }
}