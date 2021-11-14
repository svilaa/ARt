
<div align="center">
 
# ARt
 
</div>

[![](https://img.shields.io/badge/itch.io-ARt-blue)](https://svila.itch.io/art)
[![](https://img.shields.io/badge/direct%20link-ARt-green)](https://itch.io/embed-upload/4769452?color=333333)





<img src="/Assets/Resources/art_log_cut_fix.png" align="right" />

### ARt és una aplicació per a PC, Android i Web desenvolupada en Unity, que permet veure el món amb nous matissos cromàtics i geomètrics.


## Instruccions
 - En obrir l'aplicació, es demanarà el permís de la càmara. És possible que un cop donat el permís, l'app no funcioni. Cal tancar i tornar a obrir.
 - Tap a la part esquerra de la pantalla: Intercanvia entre la càmara frontal i trasera.
 - Tap a la part dreta de la pantalla: Fa una fotografia. Les imatges estan disponibles a /Android/data/com.svila.ARt/files en el cas d'Android, i a C:\Users\<nom-usuari>\AppData\LocalLow\svila\ARt en Windows. Amb Unity no s'ha trobat una millor manera de guardar les imatges sense demanar permissos, d'aquesta manera l'aplicació només té accès a la seva carpeta.
 - Botó Back: Tanca l'aplicació.

## Requisits
 - Windows 64-bits
 - Android >=4.4
 - Firefox o Edge

## Fonts
 - S'han utilitzat recursos ja desenvolupats durant el TFM i s'han agregat nous shaders gràfics.
 - Standard Assets
 - MorePPEffects
 - Versió de Unity: 2020.3.0f1

## Efectes disponibles

Cada efecte té una probabilitat d'apareixer, un rang de temps d'actuació i un rang de potència variable. Aleatòriament els efectes apareixen i desapareixen, es combinen amb d'altres, creant sinèrgies entre ells. Mai haurà dos fotogrames iguals. A vegades no apareixeran bones combinacions, però si tota l'estona es generessin imatges impactants, es perdria la motivació en trobar aquests moments, per tant, es fomenta la paciència i l'atenció en la cerca de bones instantànies efímeres, que podran ser inmortalitzades en el temps tocant la part dreta de la pantalla.

 - Pixelation
 - Chromatic aberration
 - Gamma color
 - Radial blur (millorat amb moviment automàtic per la pantalla, abans seguia el cursor)
 - Waves
 - FOV
 - Data corruption
 - Sobel
 - Wiggle
 - Headache
 - Emboss
 - Bleach bypass
 - Posterization

## TODOs
 - [ ] Arreglar la càmara frontal, l'orientació de la càmara no és correcta.
 - [ ] Que els efectes es moguin en funció de la música, està implementat al TFM però les modificacions portarien temps.
 - [ ] Suport per a VR.
 - [ ] La càmara no funciona a Chrome.
 - [ ] En Web al mòbil tampoc va bé l'orientació de la càmara i es fica la frontal per defecte.
