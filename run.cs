using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace run{
    class Program{
      static void Main() {
        int point;
        point=0;
        Car[] veiculo = new Car[6];
        menu(point, veiculo);
        
        Console.ReadKey();
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
      static void menu(int ponto, Car[] vei){
        write("\t\t----RUN GAME----");
        write("\tpontos: "+ponto) ;
        write("\n\tDigite:");
        write("\t\t1) para jogar");
        write("\t\t0) para sair");
        sw(Console.ReadLine(), ponto, vei);
      }
      static void menu2(int ponto, Car[] veiculo){
        write("\t\t----Menu----");
        write("\tpontos: "+ponto);
        write("\n\tDigite:");
        write("\t\t1) ver veiculos");
        write("\t\t2) para criar um novo veiculo");
        write("\t\t3) para voltar para o menu");
        write("\t\t0) para sair");
        sw2(Console.ReadLine(), ponto, veiculo);
      }
      static void write(string texto){
        Console.WriteLine(texto);
      }
      static void sw(string res, int ponts, Car[] veic){
        switch(res){
            case "1":
                c();
                menu2(ponts, veic);
            break;
            case "0":
                Environment.Exit(0); 
            break;
            default:
                c();
                write("Digite algo valido\n");
                menu(ponts, veic);
            break;
        }
      }
      static void sw2(string res, int ponts, Car[] veic){
        switch(res){
            case "1":
                c();
                ver(ponts, veic);
            break;
            case "2":
                c();
                criar(ponts, veic);
            break;
            case "3":
                c();
                menu(ponts, veic);
            break;
            case "0":
                Environment.Exit(0); 
            break;
            default:
                c();
                write("Digite algo valido\n");
                menu2(ponts, veic);
            break;
        }
      }
      static void c(){
        Console.Clear();
      }
      static void criar(int ponto, Car[] veicu){
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
                veicu[lp].setN("\n");
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
      static void ver(int ponto, Car[] veicu){
        int lp;
        string res;
        res= "";
        for(lp=0; lp<6; lp++){
            string ap;
            ap = veicu[lp].getApar();
            if(ap!=null){
                res=res+"\n"+ap;
            }
        };
        write(res);
      }
    }
    public class Car{
        public string apar;
        public int vel;
        public string n;
        // statics
            //aparencia
            public string getApar()
            {
                return apar;
            }
            public void setApar(string aparencia)
            {
                this.apar = "\t\t\t\t\t\t"+aparencia;
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
            //cami
            public string getN()
            {
                return n;
            }
            public void setN(string linha)
            {
                this.n = linha;
            }
            
        //run
        public string run(int percoreu){
            string ret;
            ret="";
            int lp;
            for(lp=0; lp<percoreu; lp++){
                ret = ret+this.n;
            };
            return ret;
        }
    }
}
