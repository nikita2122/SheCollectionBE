export enum CategoryTypeEnum {
  Product = 1,
  Service,
}

export const CategoryTypeToLabel: Record<CategoryTypeEnum, string> = {
  [CategoryTypeEnum.Product]: 'products',
  [CategoryTypeEnum.Service]: 'service',
};
