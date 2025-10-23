import { createFileRoute } from '@tanstack/react-router'
import ProductList from '../features/products/products-list'
export const Route = createFileRoute('/products')({
  component: ProductList,
})