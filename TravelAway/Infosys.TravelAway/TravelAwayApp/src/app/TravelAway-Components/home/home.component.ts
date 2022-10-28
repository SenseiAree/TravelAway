import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor() { }
  linkOfImages = [
    ["https://i1.wp.com/aucklandandbeyond.co.nz/wp-content/uploads/2017/10/rsz_auckland_city_sunset.jpg?fit=1920%2C1080&ssl=1",
      "Auckland",
      "Auckland is a large metropolitan city in the North Island of New Zealand. The most populous urban area in the country and the fifth largest city in Oceania."
    ],
    ["https://www.nyrentownsell.com/blog/wp-content/uploads/2020/11/manhattan-bridge-bridge-P8Y6L9Z-1.jpg",
      "New York",
      "New York, often called New York City is the most populous city in the United States.New York is the most photographed city in the world."
    ],
    ["https://www.nationalgeographic.com/content/dam/student-expeditions/Destinations/Europe/Berlin-Photo-Workshop/hero-berlin-1.ngsversion.1601577739164.adapt.1900.1.jpg",
      "Berlin",
      "Berlin is well recognized for its historical associations as Germany's capital, internationalism and a plethora of museums, palaces, and other historic monuments."
    ]

  ]

  ngOnInit(): void {
  }

}
