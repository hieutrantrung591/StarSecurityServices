class Leaflet {
    constructor(containerId, currentView = [21.207459, 78.222656]) {
        this.containerId = containerId;
        this.currentView = currentView;
        this.map = L.map(containerId).setView(currentView, 5)
        const accessToken = "pk.eyJ1IjoibG9jdGsiLCJhIjoiY2t4cTlrb3RmNG0zejJubWZzcnhzODIzbyJ9.ywVPFf9BkTpMujIyr1UqSA"

        L.tileLayer('https://api.mapbox.com/styles/v1/{id}/tiles/{z}/{x}/{y}?access_token={accessToken}', {
            maxZoom: 18,
            id: 'mapbox/streets-v11',
            tileSize: 512,
            zoomOffset: -1,
            accessToken: accessToken
        }).addTo(this.map);
    }

    getMakerData() {
        if (this.data) {
            return this.data
        }
        const data = []
        const branchList = document.querySelectorAll('.branch-list ul li');

        branchList.forEach(item => {
            const dataPos = JSON.parse(item.querySelector('.branch-position').textContent)
            const branchName = item.querySelector('.branch-name').textContent
            const address = item.querySelector('.address').textContent
            data.push({
                pos: dataPos,
                branchName,
                address
            })
            console.log(dataPos)
        })
        this.data = data;
        return this.data;
    }

    displayMarkers(data) {
        data.map(branch => {
            const marker = L.marker(branch.pos).addTo(this.map);
            marker.bindPopup(`<b>${branch.branchName}</b><div>${branch.address}</div>`).openPopup();
        })
    }

    viewPositionOnClick() {
        const popup = L.popup();

        const onMapClick = (e) => {
            popup
                .setLatLng(e.latlng)
                .setContent(`You clicked the map at <b class="text-primary">${e.latlng.toString()}</b>`)
                .openOn(this.map);
        }
        this.map.on('click', onMapClick);
    }
}