using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace run{
    class Program{
      static void Main(){//static para iniciar o game
        int point;//var para guadar pontos 
        point=0;//primeira quantidade de pontos
        Car[] veiculo = new Car[6];//criando carro
        menu(point, veiculo);//enviando tudo para o menu para nunca mais voltar
        
        Console.ReadKey();
      }
      static void exit(){//função para sair
        Environment.Exit(0);
      }
      static void play(int pont, Car[] veiculo){
        string res;
        write("escolha um carro digite 1 a 6, e caso que voltar digite 10, e 0 para sair");
        res = Console.ReadLine();
        if(res=="0"){
            exit();//fechar
        }else if(res=="10"){
            c();
            ver(pont, veiculo);//retornar para a garragem
        }else if(int.Parse(res)>0 && int.Parse(res)<7){
            if(veiculo[int.Parse(res)- 1] != null){
                int a = int.Parse(res)- 1;
                int vel= veiculo[a].getVel();
                int lp, lp2;
                while(1==1){
                    c();
                    int x= veiculo[a].getX();
                    int y= veiculo[a].getY();
                    string[] linha=new string[5];
                    string[,] matrix = new string[90,5];
                    write("aperte w para subir");
                    write("aperte s para decer");
                    write("aperte m para voltar para o menu");
                    write("aperte 0 para fechar o programa");
                    write("velocidade do veiculo: "+vel+"km");
                    for(lp=0; lp<5; lp++){
                        for(lp2=0; lp2<90; lp2++){
                            if(lp2==x && lp==y){
                                matrix[lp2,lp]=veiculo[a].getApar();
                            }else{
                                matrix[lp2,lp]=" ";
                            }
                            linha[lp]=linha[lp]+matrix[lp2,lp];
                        };
                        write("\t"+linha[lp]);
                    };
                    ConsoleKeyInfo key1 = Console.ReadKey();
                    if(key1.KeyChar.ToString() == "s"){
                        if(y<4){
                            veiculo[int.Parse(res)- 1].setY((y+ 1));
                        }
                    }else if(key1.KeyChar.ToString() == "w"){
                        if(y!=0){
                            veiculo[int.Parse(res)- 1].setY((y- 1));
                        }
                    }else if(key1.KeyChar.ToString() == "m"){
                        c();
                        ver(pont, veiculo);
                    }else if(key1.KeyChar.ToString() == "0"){
                        exit();
                    };
                };
            }else{
                c();
                write("veiculo selecionado não existe");
                ver(pont, veiculo);
            }
        }else{
            c();
            write("siga o que foi pedido ao escolher a opição 2\n");
            ver(pont, veiculo);//retornar para a garragem para recelecionar a opção correta
        };
      }
      static void menu(int ponto, Car[] vei){//menu 1
        write("\t\t----RUN GAME----");//titulo
        write("\tpontos: "+ponto) ;//medidor de pontos
        write("\n\tDigite:");
        write("\t\t1) para jogar");
        write("\t\t0) para sair");
        sw(Console.ReadLine(), ponto, vei);
      }
      static void menu2(int ponto, Car[] veiculo){//menu 2
        write("\t\t----Menu----");
        write("\tpontos: "+ponto);
        write("\n\tDigite:");
        write("\t\t1) ver veiculos");
        write("\t\t2) para criar um novo veiculo");
        write("\t\t3) para voltar para o menu");
        write("\t\t0) para sair");
        sw2(Console.ReadLine(), ponto, veiculo);
      }
      static void write(string texto){//função para escrever
        Console.WriteLine(texto);
      }
      static void sw(string res, int ponts, Car[] veic){//switch 1
        switch(res){
            case "1":
                c();
                menu2(ponts, veic);//menu dois
            break;
            case "0":
                exit();//fechar
            break;
            default:
                c();
                write("Digite algo valido\n");
                menu(ponts, veic);//retornar para o menu para recelecionar a opção correta
            break;
        }
      }
      static void sw2(string res, int ponts, Car[] veic){//switch 2
        switch(res){
            case "1":
                c();
                ver(ponts, veic);//ver veiculos
            break;
            case "2":
                c();
                criar(ponts, veic); //criar veiculo
            break;
            case "3":
                c();
                menu(ponts, veic);//retornar para o menu inicial
            break;
            case "0":
                exit();//fechar 
            break;
            default:
                c();
                write("Digite algo valido\n");
                menu2(ponts, veic);
            break;
        }
      }
      static void c(){//função para limpar
        Console.Clear();
      }
      static void criar(int ponto, Car[] veicu){//criar
        c();
        string r;
        int lp;
        write("\nDefina a aparencia do seu carro:\n exemplo de aparencia: o-`o\n");
        r = Console.ReadLine();
        for(lp=0; lp<6; lp++){
            if(veicu[lp]==null){
                veicu[lp]= new Car();
                veicu[lp].setApar(r);
                veicu[lp].setVel(60);
                veicu[lp].setY(0);
                veicu[lp].setX(25);
                c();
                write("veiculo criado");
                menu2(ponto, veicu);
                break;
            }
        }
        if(lp==6){
            c();
            write("você chegou no limite de criar veiculos");
            menu2(ponto, veicu);
        }
      }
      static void ver(int ponto, Car[] veicu){//mostrar veiculos
        if(veicu[0] != null || veicu[1] != null || veicu[2] != null || veicu[3] != null || veicu[4] != null || veicu[5] != null){
            int lp;
            string res;
            res= "";
            for(lp=0; lp<6; lp++){
                string ap;
                if(veicu[lp] != null){
                    ap = veicu[lp].getApar();
                    res=res+"\n\n\tVaga "+(lp + 1)+"\n\n\t"+ap+"\n\t"+(veicu[lp].getVel())+"km/s\n\n\n";
                }
            };
            write("\t\t----Garagem/estacionamento----");
            write(res);
            menu3(ponto, veicu);   
        }else{
            write("sua garragem não tem veiculos");
            menu2(ponto, veicu);
        }
      }
      static void menu3(int ponto, Car[] veiculo){
        write("\tpontos: "+ponto);
        write("\n\tDigite:");
        write("\t\t1) para jogar com um veiculo");
        write("\t\t2) para excluir um veiculo");
        write("\t\t3) para aprimorar um veiculo");
        write("\t\t4) para voltar para o menu");
        write("\t\t0) para sair");
        sw3(Console.ReadLine(), ponto, veiculo);
      }
      static void sel(int ponto, Car[] veiculo){
        string res;
        write("escolha um carro digite 1 a 6, e caso que voltar digite 10, e 0 para sair");
        res = Console.ReadLine();
        if(res=="0"){
            exit();//fechar
        }else if(res=="10"){
            c();
            ver(ponto, veiculo);//retornar para a garragem
        }else if(int.Parse(res)>0 && int.Parse(res)<7){
            if(veiculo[int.Parse(res)- 1] != null){
                veiculo[(int.Parse(res))- 1]=null;
                c();
                menu2(ponto, veiculo);//volar para o menu para impedir erro   
            }else{
                c();
                write("veiculo selecionado não existe");
                ver(ponto, veiculo);
            }
        }else{
            c();
            write("siga o que foi pedido ao escolher a opição 2\n");
            ver(ponto, veiculo);//retornar para a garragem para recelecionar a opção correta
        };
      }
      static void sel2(int ponto, Car[] veiculo){
        string res;
        write("escolha um carro digite 1 a 6, e caso que voltar digite 10, e 0 para sair");
        res = Console.ReadLine();
        if(res=="0"){
            exit();//fechar
        }else if(res=="10"){
            c();
            ver(ponto, veiculo);//retornar para a garragem
        }else if(int.Parse(res)>0 && int.Parse(res)<7){//aprimorar
            if(veiculo[int.Parse(res)- 1] != null){
                veiculo[(int.Parse(res))- 1].setVel(veiculo[(int.Parse(res))- 1].getVel() + 10);
                if(ponto!=0){
                    ponto = ponto - 100;
                    c();
                    ver(ponto, veiculo);//volar para garragem
                }else{
                    c();
                    write("seus pontos para aprimorar acabaram!!");
                    ver(ponto, veiculo);//volar para garragem
                };
            }else{
                c();
                write("veiculo selecionado não existe");
                ver(ponto, veiculo);
            };
        }else{
            c();
            write("siga o que foi pedido ao escolher a opição 3\n");
            ver(ponto, veiculo);//retornar para a garragem para recelecionar a opção correta
        };
      }
      static void sw3(string res, int ponts, Car[] veic){
        switch(res){
            case "1":
                play(ponts, veic);
            break;
            case "2":
                sel(ponts, veic);//Selecionar o veiculo e excluir
            break;
            case "3":
                sel2(ponts, veic);//Selecionar o veiculo e aprimorar
            break;
            case "4":
                c();
                menu2(ponts, veic);//voltar para o menu anterior
            break;
            case "0":
                exit();//fechar
            break;
            default:
                c();
                write("Digite algo valido\n");
                ver(ponts, veic);//retornar para o menu para recelecionar a opção correta
            break;
        }
      }
    }
    public class Car{
        public string apar;
        public int vel;
        public int x;
        public int y;
        // statics
            //aparencia
            public string getApar()
            {
                return apar;
            }
            public void setApar(string aparencia)
            {
                this.apar = aparencia;
            }
            //velocidade
            public int getVel()
            {
                return vel;
            }
            public void setVel(int speed)
            {
                this.vel = speed;
            }
            //y
            public int getY()
            {
                return y;
            }
            public void setY(int linha)
            {
                this.y = linha;
            }
            //x
            public void setX(int percoreu){
                this.x = percoreu;
            }
            public int getX(){
                return x;
            }
    }
    //definir possição das moedas e obstáculos
    public class obj{
        public int x;
        public int y;
        // statics
            //y
            public int getY()
            {
                return y;
            }
            public void setY(int linha)
            {
                this.y = linha;
            }
            //x
            public void setX(int percoreu){
                this.x = percoreu;
            }
            public int getX(){
                return x;
            }
    }
    //pontos
    public class pont:obj{
        public string apar;
        public int pont;
        // statics
            //aparencia
            public string getApar()
            {
                return apar;
            }
            public void setApar(string aparencia)
            {
                this.apar = aparencia;
            }
            //pontos que da
            public int getPont()
            {
                return pont;
            }
            public void setPont(int pt)
            {
                this.pont = pt;
            }
    }
}


