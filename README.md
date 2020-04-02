

Följ dessa guidelines så kommer vi inte stöta på problem.

"Master är helig jord som testarna ska testa och ska innehålla så fungerande kod som möjligt. En feature är inte klar om den inte gjorts en merge till master. Alltså behöver ni göra det minst en gång per feature i varje sprint."

När du arbetar på din branch är du i en git fristad, pusha broken kod. Gör konstiga git operationer som du får feeling för. Bara du inte gör någonting med merge eller en annan branch kan du känna dig trygg.

Guidelines att följa:

    Skapa en ny branch per feature att utveckla på
    Utveckla klart din feature på din branch
    Säkerställ kvalité på din feature
    Byt till master branchen
    Gör en pull på master branchen
    Fixa eventuella merge-conflicts
    Testa hela appen igen, se nedanstående “vid buggar” checklista
    Om det inte finns några buggar > pusha till master
    Gör en merge ifrån din feature branch

Om du hittar buggar på steg 8:

    Ta bort den lokala icke-pushade committen som har skapats av merge operationen
    Gå tillbaka till din branch
    Gör en merge av master till din branch
    Fixa eventuella merge-conflicts
    Fixa buggarna, committa och pusha till din branch
    Starta om hela checklistan. Inklusive steg 3 och steg 8!

Definition of done!

    Alla sub-tasks Done
    Written down what user story is supposed to demonstrate
    Commit-message inlcudes "Jira Issue ID"
    Code follows convention decided upon
    Automated testcase implemented for 1 happy-path testcase
    No known bugs
    Merged to master
    Code review

