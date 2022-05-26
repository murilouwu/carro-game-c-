using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace run{
    class Program{
      static void Main() {
        menu();
        sw(Console.ReadLine());
        Console.ReadKey();
      }
      static void play(Car veiculo){
        int dist;
        dist = 0;
        while(1==1){
            string esc, carro;
            c();
            write("aperte m para voltar para o menu");
            esc = veiculo.run(dist);
            carro = veiculo.getApar();
            write(esc+carro);
            ConsoleKeyInfo key1 = Console.ReadKey();
            if(key1.KeyChar.ToString() == "r"){
                dist = dist + 1;
            }else if(key1.KeyChar.ToString() == "m"){
                c();
                Main();
            };
        };
      }
      static void menu(){
        write("\t\t----MENU----");
        write("\n\tDigite:");
        write("\t\t1) para jogar");
        write("\t\t2) para sair");
      }
      static void write(string texto){
        Console.WriteLine(texto);
      }
      static void sw(string res){
        switch(res){
            case "1":
                c();
                criar();
            break;
            case "2":
                Environment.Exit(0); 
            break;
            default:
                c();
                write("Digite algo valido\n");
                Main();
            break;
        }
      }
      static void c(){
        Console.Clear();
      }
      static void criar(){
        string r;
        c();
        Car carro = new Car();
        write("\nDefina a aparencia do seu carro:\n exemplo de aparencia: o-`o\n");
        r = Console.ReadLine();
        carro.setApar(r);
        c();
        while(1==1){
            string res;
            write("\nDefina a velociadade de 1 a 3");
            res = Console.ReadLine();
            if(res=="1" || res=="2" || res=="3"){
                carro.setVel(int.Parse(res));
                break;
            }else{
                c();
                write("digite um valor valido\n");
            }
        };
        carro.setCami(" ");
        play(carro);
      }
    }
    public class Car{
        public string apar;
        public int vel;
        public string cami;
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
            //cami
            public string getCami()
            {
                return cami;
            }
            public void setCami(string tab)
            {
                int lp;
                for(lp=0; lp<vel; lp++){
                    tab= tab+" ";
                };
                this.cami = tab;
            }
            
        //run
        public string run(int percoreu){
            string ret;
            ret="";
            int lp;
            for(lp=0; lp<percoreu; lp++){
                ret = ret+this.cami;
            };
            return ret;
        }
    }
}
