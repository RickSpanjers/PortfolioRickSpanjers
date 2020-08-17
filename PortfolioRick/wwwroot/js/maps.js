function initMap() {
    var map = new google.maps.Map(document.getElementById('map'), {
        zoom: 15,
        center: { lat: 51.4744874, lng: 5.268223900000066 },
        zoomControl: true,
        zoomControlOptions: {
            style: google.maps.ZoomControlStyle.SMALL,
        },
        disableDoubleClickZoom: true,
        mapTypeControl: false,
        scaleControl: false,
        scrollwheel: false,
        panControl: false,
        streetViewControl: true,
        draggable: true,
        overviewMapControl: false,
        overviewMapControlOptions: {
            opened: false,
        },
        mapTypeId: google.maps.MapTypeId.ROADMAP,
        styles: [{ "featureType": "administrative", "elementType": "all", "stylers": [{ "visibility": "on" }, { "saturation": -100 }, { "lightness": 20 }] }, { "featureType": "road", "elementType": "all", "stylers": [{ "visibility": "on" }, { "saturation": -100 }, { "lightness": 40 }] }, { "featureType": "water", "elementType": "all", "stylers": [{ "visibility": "on" }, { "saturation": -10 }, { "lightness": 30 }] }, { "featureType": "landscape.man_made", "elementType": "all", "stylers": [{ "visibility": "simplified" }, { "saturation": -60 }, { "lightness": 10 }] }, { "featureType": "landscape.natural", "elementType": "all", "stylers": [{ "visibility": "simplified" }, { "saturation": -60 }, { "lightness": 60 }] }, { "featureType": "poi", "elementType": "all", "stylers": [{ "visibility": "off" }, { "saturation": -100 }, { "lightness": 60 }] }, { "featureType": "transit", "elementType": "all", "stylers": [{ "visibility": "off" }, { "saturation": -100 }, { "lightness": 60 }] }],
    });
    var locations = [
        ['SpanDev Webdevelopment', 'Neereindseweg 44a <br />5091RD Oostelbeers', '06 31272163', 'info@spandev.nl', 'www.rickspanjers.nl', 51.4744874, 5.268223900000066, 'http://www.rickspanjers.nl/wp-content/uploads/2017/05/contact_image-1.png']
    ];
    for (i = 0; i < locations.length; i++) {
        if (locations[i][1] == 'undefined') { description = ''; } else { description = locations[i][1]; }
        if (locations[i][2] == 'undefined') { telephone = ''; } else { telephone = locations[i][2]; }
        if (locations[i][3] == 'undefined') { email = ''; } else { email = locations[i][3]; }
        if (locations[i][4] == 'undefined') { web = ''; } else { web = locations[i][4]; }
        if (locations[i][7] == 'undefined') { markericon = ''; } else { markericon = locations[i][7]; }
        marker = new google.maps.Marker({
            icon: markericon,
            position: new google.maps.LatLng(locations[i][5], locations[i][6]),
            map: map,
            title: locations[i][0],
            desc: description,
            tel: telephone,
            email: email,
            web: web
        });
        if (web.substring(0, 7) != "https://") {
            link = "https://" + web;
        } else {
            link = web;
        }
        bindInfoWindow(marker, map, locations[i][0], description, telephone, email, web, link);
    }
    function bindInfoWindow(marker, map, title, desc, telephone, email, web, link) {
        var infoWindowVisible = (function () {
            var currentlyVisible = false;
            return function (visible) {
                if (visible !== undefined) {
                    currentlyVisible = visible;
                }
                return currentlyVisible;
            };
        }());
        iw = new google.maps.InfoWindow();
        google.maps.event.addListener(map, 'idle', function () {
            if (infoWindowVisible()) {
            } else {
                var html = "<div style='color:#000;background-color:#fff;padding:5px;width:200px;'><h4>" + title + "</h4><p>" + desc + "<br />" + telephone + "<br /><a href='mailto:" + email + "' >" + email + "</a><br /></div>";
                iw = new google.maps.InfoWindow({ content: html });
                iw.open(map, marker);
                map.setCenter(marker.getPosition())
                infoWindowVisible(true);
            }

        });

        google.maps.event.addDomListener(window, 'resize', function () {
            map.setCenter({ lat: 51.4744874, lng: 5.268223900000066 });
        });


    }

}
