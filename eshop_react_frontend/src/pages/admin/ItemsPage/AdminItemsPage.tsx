import React from 'react';
import './AdminItemsPage.scss';
import Grid from '@mui/material/Grid';
import { IItem } from '../../../Entities/Item';
import { ItemCardComponent } from '../../../components/ItemCard/ItemCardComponent';
import { CategoryCardComponent } from '../../../components/CategoryCard/CategoryCardComponent';
import { useLocation } from "react-router-dom"

export function AdminItemsPage() {
  const location = useLocation();
  const [Items, SetItems] = React.useState<Array<IItem>>();

  console.log(location);
  console.log('https://localhost:7157/api' + location.pathname + location.search);

  React.useEffect(() => {
    fetch('https://localhost:7157/api' + location.pathname + location.search)
    .then(res => res.json())
    .then(res => {
      if (Items === undefined)
        SetItems(res);
    })
  })

  return (
    <div className='PopularCategoryText'>Популярные категории
      <div className='PopularCategory'>
        <CategoryCardComponent displayName='Настенные' categoryImage='https://i.imgur.com/U3ewjC5.png'/>
        <CategoryCardComponent displayName='Встроенные' categoryImage='https://i.imgur.com/xO2jyph.png'/>
        <CategoryCardComponent displayName='Встроенные' categoryImage='https://i.imgur.com/D6UpQdt.png'/>
        <CategoryCardComponent displayName='Потолочные' categoryImage='https://i.imgur.com/YP8VQ3I.png'/>
      </div>
    </div>


      /*<Grid container spacing={6}>
        {Items?.map((item : IItem) => {
          return (
            <Grid xs={6}>
              <ItemCardComponent 
                title={item.title}
                description={item.description}
                price={item.price}
                discountPolicy={item.discountPolicy.discountPolicy}
                rating={item.rating}
                stock={item.stock}
                brand={item.brand.displayName}
                category={item.category.displayName}
                thumbnail={item.thumbnail}
                images={item.images}
              />
            </Grid>
          )
        })}
      </Grid>
      */
  );
}