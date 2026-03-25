function toonAlbum() {
    document.getElementById('albumKeuze').style.display = 'block';
    document.getElementById('nummerKeuze').style.display = 'none';

    document.querySelector('#albumKeuze select').name = 'albumId';
    document.querySelector('#nummerKeuze select').name = '';
}

function toonNummer() {
    document.getElementById('albumKeuze').style.display = 'none';
    document.getElementById('nummerKeuze').style.display = 'block';

    document.querySelector('#nummerKeuze select').name = 'songId';
    document.querySelector('#albumKeuze select').name = '';
}