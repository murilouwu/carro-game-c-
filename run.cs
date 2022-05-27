using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace run{
    class Program{
      static void Main(){//static para iniciar o game
        int point;//var para guadar pontos 
        point=400;//primeira quantidade de pontos
        Car[] veiculo = new Car[6];//criando carro
        menu(point, veiculo);//enviando tudo para o menu para nunca mais voltar
        
        Console.ReadKey();
      }
      static void exit(){
        Environment.Exit(0);
      }
      static void play(Car veiculo, int pont){
        /*int dist;
        dist = 0;
        while(1==1){
            string esc, carro;
            int vel;
            vel = veiculo.getVel();
            c();
            write("aperte m para voltar para o menu");
            write("aperte w para subir");
            write("aperte s para decer");
            write("velocidade do veiculo: "+vel+"km");
            esc = veiculo.run(dist);
            carro = veiculo.getApar();
            write(esc+carro);
            ConsoleKeyInfo key1 = Console.ReadKey();
            if(key1.KeyChar.ToString() == "s"){
                if(dist<5){
                    dist = dist + 1;
                }
            }else if(key1.KeyChar.ToString() == "w"){
                if(dist!=0){
                    dist = dist - 1;
                }
            }else if(key1.KeyChar.ToString() == "m"){
                c();
                menu2(pont);
            };
        };*/
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
                veicu[lp].setX(30);
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
                    res=res+"\n\n\tVeiculo "+(lp + 1)+"\n\n\t"+ap+"\n\t"+(veicu[lp].getVel())+"km/s\n\n\n";
                }
            };
            write("\t\t----Garagem----");
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
        write("escolha um carro digite 1 a 6 e caso que voltar digite 10 e 0 para sair");
        res = Console.ReadLine();
        if(res=="0"){
            exit();//fechar
        }else if(res=="0"){
            c();
            ver(ponto, veiculo);//retornar para a garragem
        }else if(int.Parse(res)>0 && int.Parse(res)<7){
            veiculo[(int.Parse(res))- 1]=null;
            c();
            menu2(ponto, veiculo);//volar para o menu para impedir erro 
        }else{
            c();
            write("sigua o que foi pedido ao escolher a opição 2\n");
            ver(ponto, veiculo);//retornar para a garragem para recelecionar a opção correta
        };
      }
      static void sel2(int ponto, Car[] veiculo){
        string res;
        write("escolha um carro digite 1 a 6 e caso que voltar digite 10 e 0 para sair");
        res = Console.ReadLine();
        if(res=="0"){
            exit();//fechar
        }else if(res=="0"){
            c();
            ver(ponto, veiculo);//retornar para a garragem
        }else if(int.Parse(res)>0 && int.Parse(res)<7){
            veiculo[(int.Parse(res))- 1].setVel(veiculo[(int.Parse(res))- 1].getVel() + 10);
            ponto = ponto - 100;
            c();
            ver(ponto, veiculo);//volar para o menu para impedir erro 
        }else{
            c();
            write("sigua o que foi pedido ao escolher a opição 2\n");
            ver(ponto, veiculo);//retornar para a garragem para recelecionar a opção correta
        };
      }
      static void sw3(string res, int ponts, Car[] veic){
        switch(res){
            case "2":
                sel(ponts, veic);//Selecionar o veiculo
            break;
            case "3":
                sel2(ponts, veic);//Selecionar o veiculo
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
            public int gety()
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
}
