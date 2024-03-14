import './CategoryCardComponent.scss';

interface ICategoryCardProps{
  displayName : string;
  categoryImage : string;
}

export function CategoryCardComponent(category : ICategoryCardProps) {

  return (
    <div className='CategoryCard'>
      <div className='CategoryCard-Image'>
        <img
        alt='CategoryItem' 
        src={category.categoryImage}
        />
      </div>
      <div className='CategoryCard-DisplayName'>
        {category.displayName}
      </div>
    </div>

  );
}