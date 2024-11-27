import Link from "next/link";

export async function getStaticProps() {
  const res = await fetch('http://localhost:3001/categories');
  const categories = await res.json();

  return {
    props: {
      categories,
    },
  };
}

export default function Home({ categories }) {
  return (
    <div className="flex flex-col items-center px-10 py-8">
      <h1 className="text-3xl font-bold mb-12">Blog</h1>

      <h3 className="text-xl font-semibold">Categories: </h3>
      
      <ul className="text-lg text-center">
        {categories.map((category) => (
          <li key={category.id}>
            <Link href={`/category/${category.id}`} className="hover:underline hover:text-green-600">
              {category.name}
            </Link>
          </li>
        ))}
      </ul>
    </div>
  );
}
