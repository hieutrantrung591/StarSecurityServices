const data = []
const branchList = document.querySelectorAll('.branch-list ul li');

branchList.forEach(item => {
    const dataPos = JSON.parse(item.getAttribute('data-pos'))
    const branchName = item.querySelector('b').textContent
    const address = item.querySelector('.address').textContent
    data.push({
        pos: dataPos,
        branchName,
        address
    })
})

const map = L.map('map').setView(data[0].pos, 5);

const accessToken = "pk.eyJ1IjoibG9jdGsiLCJhIjoiY2t4cTlrb3RmNG0zejJubWZzcnhzODIzbyJ9.ywVPFf9BkTpMujIyr1UqSA"

L.tileLayer('https://api.mapbox.com/styles/v1/{id}/tiles/{z}/{x}/{y}?access_token={accessToken}', {
    /*attribution: 'Map data &copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors, Imagery © <a href="https://www.mapbox.com/">Mapbox</a>',*/
    maxZoom: 18,
    id: 'mapbox/streets-v11',
    tileSize: 512,
    zoomOffset: -1,
    accessToken: accessToken
}).addTo(map);

data.map(branch => {
    const marker = L.marker(branch.pos).addTo(map);
    marker.bindPopup(`<b>${branch.branchName}</b><div>${branch.address}</div>`).openPopup();
})





