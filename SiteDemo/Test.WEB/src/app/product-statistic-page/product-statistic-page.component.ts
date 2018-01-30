import { Component, OnInit } from '@angular/core';
import { ProductsService } from "../_services/product.service";
import { GroupItem } from "../_models/groupItem";

@Component({
  selector: 'product-statistic-page',
  templateUrl: './product-statistic-page.component.html',
  styleUrls: ['./product-statistic-page.component.css']
})
export class ProductStatisticPageComponent implements OnInit {
  length: number;
  pageSize = 4;

  groups: GroupItem[] = [];

  currentPage: number = 0;
  groupsCount: number = 3;

  constructor(private productService: ProductsService ) { }

  ngOnInit() {
    this.getGrouped(this.currentPage);
  }

  getGrouped(page) {
    this.currentPage = page;
    this.productService.getGroups(this.currentPage, this.groupsCount)
      .subscribe(
      pageModel => {
        this.groups = pageModel.items;
        this.length = pageModel.totalCount;
      },
      error => {
      });
  }
}
