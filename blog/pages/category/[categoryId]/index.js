import { useRouter } from 'next/router';
import Link from 'next/link';
import { categories, posts } from '@/pages/data';

export async function getStaticPaths() {
  const res = await fetch('http://localhost:3001/categories');
  const categories = await res.json();

  const paths = categories.map((category) => ({
    params: { categoryId: category.id },
  }));

  return { paths, fallback: false };
}

export async function getStaticProps({ params }) {
  const { categoryId } = params;

  const categoryRes = await fetch(`http://localhost:3001/categories/${categoryId}`);
  const category = await categoryRes.json();

  const postsRes = await fetch(`http://localhost:3001/posts?categoryId=${categoryId}`);
  const posts = await postsRes.json();

  return {
    props: {
      category,
      posts,
    },
  };
}

export default function CategoryPage({ category, posts }) {
  if (!category) {
    return <h1>Category not found</h1>;
  }

  return (
    <div className="flex flex-col items-center px-10 py-8">
      <h1 className='text-2xl font-bold mb-12'>Category: <span className='text-green-500'>{category.name}</span></h1>
      
      <ul className="text-lg text-center">
        {posts.map((post) => (
          <li key={post.id}>
            <Link href={`/category/${category.id}/post/${post.id}`} className="hover:underline hover:text-green-500">
              {post.title}
            </Link>
          </li>
        ))}
      </ul>
      
      <Link href="/" className="hover:underline hover:text-green-500 mt-10" >Home</Link>
    </div>
  );
}
