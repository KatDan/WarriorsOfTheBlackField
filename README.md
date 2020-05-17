# WarriorsOfTheBlackField
###### zápočtový program, zimný semester 2018/2019
<br/>
 
Cieľom hry je poraziť čo najviac nepriateľov, ktorých sila a diabolskosť každým levelom rastie.  

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
Nepriateľ sa správa nasledovne:
 - ak je nepriateľ vo výhode, útočí. Aby mal výhodu, musí byť splnená aspoň jedna z podmienok:
  - nepriateľ má vyššie HP ako hrdina,
  - keby zaútočil nepriateľ na hrdinu 2-krát za sebou rovnakou silou útoku, akú mal pri poslednom útočení, tak by hrdinu zabil.
 - ak je nepriateľ v nevýhode, vzdaľuje sa od hrdinu. Ak už sa nemôže viac vzdialiť, bezhlavo útočí a dúfa, že sa jeho šance na prežitie časom zvýšia.
 
 Výhodu a nevýhodu svojej pozície nepriateľ vyhodnocuje na začiatku každého svojho ťahu.
 
## Level Up
Po každom prejdenom leveli dostane hrdina k dispozícii niekoľko xp, za ktoré má možnosť vylepšiť si staty takto:
 - +1 Potion
 - +3 sila útoku
 - +7 hp
 - +2 body obrany
 
Po vyčerpaní všetkých xp, ktoré mal hrdina k dispozícii, hrdina prechádza do vyššieho levelu, v ktorom sa mu vygeneruje nový nepriateľ.
Staty nepriateľa sú náhodne generované použitím všetkých xp, ktoré by mal hrdina v danom leveli dokopy k dispozícii.

<br/>
Po smrti hrdinu si hrdina môže uložiť nahraté skóre a hrať odznova od levelu 1 s defaultnými atribútmi. 

<br/>
Userovi je dovolené ukončiť program až vtedy, keď bude spokojný s tým, ako vyzerá tabuľka High score. Žiadne konfety.
