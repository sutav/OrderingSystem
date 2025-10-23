
export default function ProductRow(props) {
  return (
    <div>
    <div>{props.product.description} </div><div>{props.product.price}</div>
   </div>
  )
}