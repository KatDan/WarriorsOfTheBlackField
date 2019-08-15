# WarriorsOfTheBlackField
###### zápočtový program, zimný semester, šk. rok 2018/2019
<br/>
 
Cieľom hry je v 5tich, stále náročnejších leveloch poraziť nepriateľa. 

## Staty
Hrdina má nasledovné staty:
- počet Potionov (viac info nižšie)
- sila útoku
- hp
- body obrany
Tieto staty si môže hrdina navyšovať po prejdení levelu použitím získaných xp.

## Ťah hrdinu
Ťah hrdinu spočíva vo zvolení si jednej zo štyroch možných akcií:
 - akcia Krok dopredu - priblíži hrdinu k nepriateľovi. Akcia je dostupná, ak je hrdina od nepriateľa ďalej ako na krok
 - akcia Krok dozadu - posunie hrdinu ďalej od nepriateľa
 - akcia Potion - ak má hrdina k dispozícii aspoň 1 potion, jeho vypitím získa +5 hp. Na začiatku je počet potionov 0.
                  Potion je možné získať po porazení nepriateľa použitím získaných xp (viď nižšie)
 - akcia Útok - Ak je hrdina bližšie ako na krok od nepriateľa, zaútočí naňho. Ujma na živote je vypočítaná vzorcom 
 
                nepriatel.akt_sila_utoku = utok + a * rand.Next(0, utok / 2) - (rand.Next(0, 51) / 40) * obrana;      
                
            
     kde a je náhodne 1 alebo -1.
     Ak nie je hrdina dostatočne blízko, akcia je platná, ale žiadnu ujmu nespôsobí.
     
## Ťah nepriateľa     
Ťah nepriateľa je náhodne vybratý zo všetkých dostupných akcií (okrem akcie Potion) takto:
 - ak nepriateľ môže zaútočiť na hrdinu, so 75% pravdepodobnosťou zaútočí a s 25% pravdepodobnosťou urobí krok dozadu.
 - ak nepriateľ nemôže zaútočiť na hrdinu, so 40% pravdepodobnosťou urobí krok vpred, so 40% pravdepodobnsťou urobí krok vzad a
 s 20% pravdepodobnosťou zaútočí bez ujmy na živote hrdinu
 - krok nepriateľa je o 33% kratší ako krok hrdinu
 
 
## Level Up
Po každom prejdenom leveli dostane hrdina k dispozícii niekoľko xp, za ktoré má možnosť vylepšiť si staty takto:
 - +1 Potion
 - +3 sila útoku
 - +7 hp
 - +2 body obrany
 
Po vyčerpaní všetkých xp, ktoré mal hrdina k dispozícii, hrdina prechádza do vyššieho levelu, v ktorom sa mu vygeneruje nový nepriateľ.
Staty nepriateľa sú náhodne generované použitím všetkých xp, ktoré by mal hrdina v danom leveli dokopy k dispozícii.

<br/>
Po smrti hrdinu začína hrdina znovu na leveli 1 s defaultnými statmi.
<br/>
Po prejdení všetkých 5 levelov je User povinný užiť si konfety a je mu dovolené ukončiť program.
