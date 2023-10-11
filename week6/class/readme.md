## 실행 결과

![image](https://github.com/wini66/game/assets/119557644/d81bf028-19c1-4657-8c5a-e4fd385af361)


## 화살 쏘기 게임

#include<stdio.h>
#include<stdlib.h>
#include<windows.h>
#include<conio.h>
#include<time.h>

void intro_game(void );
void horizontal_slide(int x, int y, char c2[]);
void draw_rectangle(int r, int c);
void display_text(int count, int r_count, int playerLevel, char name[]);
void game_control(int *r_c, int rnd, int *pla);
void gotoxy(int x, int y);

int main(void )

{
	char name[51];
	system("color 30"); //
	printf("플레이어 이름을  입력해주세요: ");
	scanf("%s", &name); 
	
	system("cls");
	
	printf("%s 님, 환영합니다!", name);
	
	HANDLE hConsole = GetStdHandle(STD_OUTPUT_HANDLE);
    SetConsoleTextAttribute(hConsole, FOREGROUND_RED | FOREGROUND_INTENSITY); // 빨간색으로 글자색 변경
	
	int playerLevel = 1;  // 플레이어 레벨
	
    int count=0, rnd;

    int r_count=0;
    
    char ch;
	
    char *target="□";
    
    srand((unsigned int)time(NULL));

    intro_game();
     
    SetConsoleTextAttribute(hConsole, BACKGROUND_BLUE);//배경 파란색으로 바꾸기
   

    do

    {

        system("cls");
		
        draw_rectangle(20, 20);

        rnd=rand()%15+4;
        	//0부터 14까지의 난수를 생성한 후에 4를 더하여 최종적으로 4부터 18까지의 값을 반환합니다.

        gotoxy(rnd, 2);

        printf("%s", target);

        count++;

        display_text(count,r_count,playerLevel,name);

        game_control(&r_count, rnd, &playerLevel);

    }while(count<10);

    return 0;

}

//게임에대한설명을출력하는함수

void intro_game(void )

{

	char ch;
    _getch();
    
     system("cls");
     printf("\n\n\n");
     printf("          □□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□\n");
     printf("          □                                                                        □\n");
     printf("          □                             화살쏘기게임                               □\n");
     printf("          □                                                                        □\n");
     printf("          □□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□\n\n\n\n");
     
     
    while (1) {
        printf("                         게임 설명창 (0) 또는 게임 시작 (1)을 선택하세요: \n");
        ch = getch();
        if (ch == '0') {
        	 system("cls");//
            printf("                    게임 설명: 스페이스바를 눌러 목표물을 명중시키세요!\n\n");
            printf("                    성공 횟수 3회당 플레이어 레벨이 1 증가합니다!\n\n");
            printf("                    플레이어 레벨이 3을 달성하면 게임이 종료됩니다!\n\n");
            printf("                    뒤로 가려면 'q'를 입력하세요.\n\n");
            ch = getch();
            if (ch == 'q') {
                system("cls");
                continue;
            }
        } else if (ch == '1') {
            break;
        }
    }

}

//로켓의위치를좌우로이동시키는함수

void horizontal_slide(int x, int y, char c2[])

{

    gotoxy(x,y);

    printf("%s", c2);

    Sleep(50);

    printf("\b ");

}

void draw_rectangle(int r, int c)

{

    int i, j;

    unsigned char a=0xa6, b[7];

 

    for(i=1;i<7;i++)

        b[i]=0xa0+i;

    printf("%c%c", a, b[3]);

    for(i=0;i<c;i++)

        printf("%c%c", a, b[1]);

 

    printf("%c%c", a, b[4]);

    printf("\n");

    for(i=0;i<r;i++)

    {

        printf("%c%c", a, b[2]);

        for(j=0;j<c;j++)

            printf(" ");

        printf("%c%c", a, b[2]);

        printf("\n");

    }

    printf("%c%c", a, b[6]);

    for(i=0;i<c;i++)

        printf("%c%c", a, b[1]);

    printf("%c%c", a, b[5]);

    printf("\n");

}

 

//시도한횟수와성공한횟수를화면에출력하는함수

void display_text(int count, int r_count, int playerLevel, char name[])

{

    gotoxy(46, 2);

    printf("스페이스키를누르면\n");

    gotoxy(46,3);

    printf("화살이발사됩니다.\n");

    gotoxy(46,5);

    printf("시도 횟수: %d", count);

    gotoxy(46,6);

    printf("성공 횟수: %d", r_count);
    
    gotoxy(46,7);

    printf("닉네임: %s", name);
    
    gotoxy(46,8);

    printf("레벨: %d", playerLevel);//
    

}

//목표물에화살쏘기게임의제어함수

void game_control(int *r_c, int rnd, int *pla)

{

    int i=1, k=1, y;
    
    

    char *horse="▲", chr;

    do

    {

        i+=k;

        if(i>20)//39 말의 최대 x좌표 크기 
        	
        	 k=-1;
        	 
           

        else if(i<3)

            k=+1;

        horizontal_slide(i/1, 21, horse);//

    }while(!_kbhit());

    chr=_getch();

    y=21;

    if(chr==32)

    {

        while(y>2)

        {

            y-=1;

            gotoxy(i+1, y);

            printf("↑");

            Sleep(50);

            printf("\b ");

        }

        if((i>=rnd-2) && (i<=rnd))

        {

            gotoxy(rnd, 2);

            printf("☆");

            gotoxy(46, 10);

            printf("    <<명중!>> ");

            Sleep(50);

            *r_c=*r_c+1;
            
            if (*r_c % 3==0) {
                *pla=*pla+1;
                           //
                        }
             if (*pla >= 3) {
               system("cls");
               printf("\n\n\n");
               printf("          □□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□\n");
               printf("          □                                                                        □\n");
               printf("          □                              c l e a r !                               □\n");
               printf("          □                     플레이어 레벨 3에 달성하였습니다!                  □\n");
               printf("          □                                                                        □\n");
               printf("          □□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□□\n\n\n\n");
        exit(0);
    }//

        }
        
         

        gotoxy(1, 24);

        printf("아무키나누르면다음진행...");

        _getch();

    }

}

void gotoxy(int x, int y)

{

    COORD Pos = { x-1, y-1 };

    SetConsoleCursorPosition(GetStdHandle(STD_OUTPUT_HANDLE), Pos);

}

